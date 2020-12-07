using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{
    public class LoginResponseModel
    {
        public string session
        {
            get;
            set;
        }

        public string externalUserId
        {
            get;
            set;
        }

        public string domainId
        {
            get;
            set;

        }
    }
}
