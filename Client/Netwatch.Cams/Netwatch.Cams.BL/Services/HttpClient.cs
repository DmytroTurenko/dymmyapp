using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace Netwatch.Cams.BL.Services
{
    public class HttpClient
    {
        /// <summary>
        /// Private custom exception.
        /// </summary>
        private class HttpWebException : System.Exception
        {
            public HttpWebException(string message)
                : base(message) { }
        }

        /// <summary>
        /// The base URL to access the Avigilon Web Endpoint.
        /// </summary>
        private string m_baseUrl;

        /// <summary>
        /// Sets the base URL to access the Avigilon Web Endpoint.
        /// </summary>
        /// <param name="baseUrl">The base URL to access Avigilon Web Endpoint.</param>
        public void SetBaseUrl(string baseUrl)
        {
            m_baseUrl = baseUrl;
        }
        /// <summary>
        /// Call HTTP POST on the base URL with given extension and json parameters.
        /// </summary>
        /// <typeparam name="TResponse">The response type we expect.</typeparam>
        /// <param name="restUrlExtension">The URL extention to append to the base URL</param>
        /// <param name="jsonParam">The json parameter to attach to the HTTP body.</param>
        /// <returns>The deserialized Object.</returns>
        public TResponse HttpPost<TResponse>(string restUrlExtension, string jsonParam)
            where TResponse : class
        {
            return HttpRequest_<TResponse>
                (System.Net.Http.HttpMethod.Post,
                restUrlExtension,
                jsonParam);
        }

        public TResponse HttpPostBinary<TResponse>(string restUrlExtension, string jsonParam)
            where TResponse : class
        {
            return HttpRequest_<TResponse>
                (System.Net.Http.HttpMethod.Post,
                restUrlExtension,
                jsonParam);
        }

        /// <summary>
        /// Call HTTP POST on the base URL with given extension and json parameters.
        /// </summary>
        /// <typeparam name="TResponse">The response type we expect.</typeparam>
        /// <param name="restUrlExtension">The URL extention to append to the base URL</param>
        /// <param name="jsonParam">The json parameter to attach to the HTTP body.</param>
        /// <returns>The deserialized Object.</returns>
        public TResponse HttpPut<TResponse>(string restUrlExtension, string jsonParam)
            where TResponse : class
        {
            return HttpRequest_<TResponse>
                (System.Net.Http.HttpMethod.Put,
                restUrlExtension,
                jsonParam);
        }
        /// <summary>
        /// Call HTTP GET on the base URL with given extension and json parameters.
        /// </summary>
        /// <typeparam name="TResponse">The response type we expect.</typeparam>
        /// <param name="restUrlExtension">The URL extention to append to the base URL</param>
        /// <param name="param">The query param to attach to the URL.</param>
        /// <returns>The deserialized Object.</returns>
        public TResponse HttpGet<TResponse>(string restUrlExtension, string param)
            where TResponse : class
        {
            return HttpRequest_<TResponse>(
                System.Net.Http.HttpMethod.Get,
                CreateUrlQuery_(restUrlExtension, param),
                null);
        }

        /// <summary>
        /// Call HTTP GET on the base URL with given extension and no parameters.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="restUrlExtension"></param>
        /// <returns></returns>
        public TResponse HttpGetWithNoParametrs<TResponse>(string restUrlExtension)
           where TResponse : class
        {
            return HttpRequest_<TResponse>(
                System.Net.Http.HttpMethod.Get,
                restUrlExtension,
                null);
        }

        /// <summary>
        /// Request the HTTP with the given parameters.
        /// </summary>
        /// <typeparam name="TResponse">The response type we expect.</typeparam>
        /// <param name="httpRequestMethod">HTTP request method.</param>
        /// <param name="restUrlExtension">The URL extension to the base URL.</param>
        /// <param name="jsonParam">Json parameter to attach to the HTTP body.</param>
        /// <param name="bIsPeek">Flag to indicate looking at the first few characters for the response.</param>
        /// <returns>The response type we expect.</returns>
        private TResponse HttpRequest_<TResponse>(
            System.Net.Http.HttpMethod httpRequestMethod,
            string restUrlExtension,
            string jsonParam)
            where TResponse : class
        {
            TResponse httpReponse = null;
            try
            {
                System.Net.HttpWebRequest httpRequest = CreateWebRequest_(httpRequestMethod, restUrlExtension);
                WriteParamToWebRequest_(httpRequest, jsonParam);


                System.Net.HttpWebResponse httpResponse = (System.Net.HttpWebResponse)httpRequest.GetResponse();


                httpReponse = HandleHttpReponse_<TResponse>(httpResponse);
            }
            catch (System.Net.WebException webEx)
            {

            }

            return httpReponse;
        }

        /// <summary>
        /// Creates and returns the web request.
        /// </summary>
        /// <param name="httpRequestMethod">The HTTP request method.</param>
        /// <param name="restUrlExtension">The extension to append to the base URL.</param>
        /// <returns>HTTP web request.</returns>
        private System.Net.HttpWebRequest CreateWebRequest_(
            System.Net.Http.HttpMethod httpRequestMethod,
            string restUrlExtension)
        {
            System.Net.HttpWebRequest httpWebRequest =
                (System.Net.HttpWebRequest)System.Net.WebRequest.Create(m_baseUrl + restUrlExtension);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = httpRequestMethod.Method;

            // allows for validation of SSL conversations
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            return httpWebRequest;
        }

        /// <summary>
        /// Writes the JSON parameter to the web request.
        /// </summary>
        /// <param name="httpWebRequest">The web request to attach the json parameter to.</param>
        /// <param name="jsonParam">The json parameter.</param>
        private void WriteParamToWebRequest_(System.Net.HttpWebRequest httpWebRequest, string jsonParam)
        {
            if (jsonParam != null)
            {
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream());

                streamWriter.Write(jsonParam);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }


        /// <summary>
        /// Handles the HTTP response.
        /// </summary>
        /// <typeparam name="TResponse">The response type we expect.</typeparam>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        private TResponse HandleHttpReponse_<TResponse>(System.Net.HttpWebResponse httpResponse)
            where TResponse : class
        {
            TResponse httpReponse = null;
            if (httpResponse != null)
            {
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string responseResult = "";
                    responseResult = streamReader.ReadToEnd();
                    if (responseResult.StartsWith("<?xml"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(TResponse));
                        MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(responseResult));
                        httpReponse = (TResponse)serializer.Deserialize(memStream);
                    }
                    else
                        httpReponse = JsonConvert.DeserializeObject<TResponse>(responseResult);

                }
            }
            return httpReponse;
        }

        /// <summary>
        /// Creates the URL by appending the query character and appending the param.
        /// </summary>
        /// <param name="restUrlExtension">The query extention for the URL.</param>
        /// <param name="param">The URL query parameter to append to the URL.</param>
        /// <returns>The query URL.</returns>
        private string CreateUrlQuery_(string restUrlExtension, string param)
        {
            return (restUrlExtension + "?" + param);
        }
    }

}
