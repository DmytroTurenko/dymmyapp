using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{
    public class LoginResponseContract
    {
        public string status
        {
            get;
            set;
        }

        public LoginResponseModel result;
    }
}
