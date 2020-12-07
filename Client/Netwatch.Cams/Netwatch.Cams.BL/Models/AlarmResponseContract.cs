using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{
    public class AlarmResponseContract
    {
        public string status
        {
            get;
            set;
        }
        public AlarmsContract result
        {
            get;
            set;
        }
    }

    public class AlarmHistoryResponseContract
    {
        public string status
        {
            get;
            set;
        }
        public AlarmEventsContract result
        {
            get;
            set;
        }
    }

    public class AlarmEventsContract
    {
        public List<AlarmEvent> events { get; set; }
    }

    public class AlarmEvent
    {
        public string type { get; set; }
        public DateTime time { get; set; }
        public string note { get; set; }
    }
}
