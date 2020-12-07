using Netwatch.Cams.BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Linq;

namespace Netwatch.Cams.BL.Services
{
    public class BusinessLogic
    {
        private HttpClient _httpClient;
        private TokenGenerator _tokenGenerator;
        private string sessionId;

        public BusinessLogic()
        {
            _httpClient = new HttpClient();
            _tokenGenerator = new TokenGenerator();
        }

        public bool Login()
        {
            try
            {
                _httpClient.SetBaseUrl(ConfigurationManager.AppSettings["baseUrl"].ToString());


                var token = _tokenGenerator.GenerateToken(ConfigurationManager.AppSettings["userNonce"].ToString(), ConfigurationManager.AppSettings["userKey"].ToString());

                var loginPostJson = JsonConvert.SerializeObject(new LoginRequestModel()
                {
                    authorizationToken = token,
                    clientName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                    password = ConfigurationManager.AppSettings["password"].ToString(),
                    username = ConfigurationManager.AppSettings["login"].ToString(),
                    siteName = ConfigurationManager.AppSettings["siteName"].ToString()
                });
                var loginResponse = _httpClient.HttpPost<LoginResponseContract>("login", loginPostJson);
                if(loginResponse?.result != null)
                {
                    sessionId = loginResponse.result.session;
                    return true;
                }
                return false;
            }
            catch( Exception ex)
            {
                return false;
            }
        }

        public bool IsAuthenticated()
        {
            return (sessionId != null);
        }

        public string GetLoginSessionId()
        {
            try
            {

                if (!IsAuthenticated())
                    Login();

                return sessionId;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<AlarmContract> GetAlarms()
        {
            string currentSessionQuery = $"session={sessionId}";
            var alarms = _httpClient.HttpGet<AlarmResponseContract>("alarms", currentSessionQuery).result.alarms;
            return alarms;
        }

        public SiteContract GetSite()
        {
            string currentSessionQuery = $"session={sessionId}";
            var site = _httpClient.HttpGet<SiteResponseContract>("site", currentSessionQuery).result;
            return site;
        }

        public List<CameraContract> GetCameras()
        {
            string currentSessionQuery = $"session={sessionId}";
            var cameras = _httpClient.HttpGet<CameraResponseContract>("cameras", currentSessionQuery).result.cameras;
            return cameras;
        }

        public List<AlarmEvent> GetEvents(string alarmId)
        {
            string currentSessionQuery = $"session={sessionId}&id={alarmId}";
            var events = _httpClient.HttpGet<AlarmHistoryResponseContract>("alarm-history", currentSessionQuery).result.events;
            return events;
        }

        public string GetLive(string cameraId, string type, string format)
        {
            string currentSessionQuery = $"{ConfigurationManager.AppSettings["baseUrl"]}media?session={sessionId}&cameraId={cameraId}&{type}={format}";
            return currentSessionQuery;
        }

        public string GetRecordedVideo(string cameraId, string date, string range)
        {
            string currentSessionQuery = $"{ConfigurationManager.AppSettings["baseUrl"]}media?session={sessionId}&cameraId={cameraId}&format=fmp4&t={date}&range={range}";
            return currentSessionQuery;
        }

        public string GetLiveAudio(string cameraId)
        {
            string currentSessionQuery = $"session={sessionId}&cameraId={cameraId}&format=mpd";
            var audio = _httpClient.HttpGet<MPD>("media", currentSessionQuery);
            var stream = audio.Period.FirstOrDefault(x => x.Representation.Any(e => e.audioSamplingRateSpecified))?.Representation.FirstOrDefault(a => a.audioSamplingRateSpecified).BaseURL;
            var uri = new Uri(ConfigurationManager.AppSettings["baseUrl"]);
            currentSessionQuery = $"{uri.AbsoluteUri.Replace(uri.AbsolutePath,"")}{stream}";
            return currentSessionQuery;
        }

    }
}
