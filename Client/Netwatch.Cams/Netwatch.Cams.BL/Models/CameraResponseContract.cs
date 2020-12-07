using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.BL.Models
{
    public class CameraResponseContract
    {
        public string status
        {
            get;
            set;
        }

        public CamerasContract result
        {
            get;
            set;
        }
    }

    public class CamerasContract
    {
        public List<CameraContract> cameras
        {
            get;
            set;
        }
    }

    public class CameraContract
    {

        public string id { get; set; }

        public string name { get; set; }

        public string model { get; set; }

        public string serial { get; set; }

        public string manufacturer { get; set; }

        public bool connected { get; set; }

        public bool active { get; set; }

        public string connectionState { get; set; }

        public string firmwareVersion { get; set; }

        public int operatingPriority { get; set; }

        public string physicalAddress { get; set; }

        public string ipAddress { get; set; }

        public object logicalId { get; set; }

        public Capabilities capabilities { get; set; }

        public bool recordedData { get; set; }

        public int defaultWidth { get; set; }

        public int defaultHeight { get; set; }

        public string location { get; set; }

        public string liveStream { get; set; }
    }

    public class Capabilities
    {

        public List<string> general { get; set; }

        public List<string> ptz { get; set; }

        public List<string> network { get; set; }

        public List<string> compression { get; set; }

        public List<string> mjpeg { get; set; }

        public List<string> h264 { get; set; }

        public List<string> acquisition { get; set; }

        public List<string> motion { get; set; }

        public List<string> digitalIo { get; set; }

        public List<string> audio { get; set; }

        public List<string> speaker { get; set; }

        public List<string> exposure { get; set; }

        public List<string> streamRecording { get; set; }

        public List<string> profileRecording { get; set; }

        public List<string> analytic { get; set; }
    }
}
