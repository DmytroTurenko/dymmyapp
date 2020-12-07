using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{
   public class SiteResponseContract
    {
        public string status
        {
            get;
            set;
        }
        public SiteContract result
        {
            get;
            set;
        }
    }

    public class SiteContract
    {
        public SiteModel site { get; set; }
    }

    public class SiteModel
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool reachable { get; set; }
    }
}
