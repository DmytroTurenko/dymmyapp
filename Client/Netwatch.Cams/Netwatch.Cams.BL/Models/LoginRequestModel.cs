using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{
    public class LoginRequestModel
    {
        public string username { get; set; }

        public string password { get; set; }

        public string siteName { get; set; }

        public string clientName { get; set; }

        public string authorizationToken { get; set; }
    }
}
