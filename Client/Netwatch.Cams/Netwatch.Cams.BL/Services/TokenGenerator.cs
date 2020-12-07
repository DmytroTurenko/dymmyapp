using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Netwatch.Cams.BL.Services
{
    public class TokenGenerator
    {
        //FO#08052002
        //1d724b6fce43957f04913a0c455bd32264df5bbd450c9819fa4492c20a95c73d
        public string GenerateToken(string userId, string userPassword)
        {
            var timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var hex = ComputeSha256Hash($"{timestamp}{userPassword}");
            var token = $"{userId}:{timestamp}:{hex}";
            return token;
        }

        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
