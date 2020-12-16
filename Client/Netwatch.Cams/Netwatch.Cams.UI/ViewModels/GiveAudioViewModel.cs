using Microsoft.Win32;
using Netwatch.Cams.BL.Models;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Input;

namespace Netwatch.Cams.UI.ViewModels
{
    public class GiveAudioViewModel : BaseViewModel
    {
        private ObservableCollection<CameraContract> _cameras;

        public ICommand GetImageCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand TransmitCommand { get; set; }

        private DialogueService _dialogueService;

        public GiveAudioViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login(Properties.user.Default.UseServiceLayer)) return;
            }

            GetImageCommand = new CustomCommand(GetImage, CanGetImageCommand);
            CloseCommand = new CustomCommand(CloseWindow, CanCloseWindow);
            TransmitCommand = new CustomCommand(Transmit, CanTransmitCommand);

            LoadCamerasInfo();
        }


        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                _selectedPath = value;
                OnPropertyChanged("SelectedPath");
            }
        }

        private void LoadCamerasInfo()
        {
            var contracts = _businessLogic.GetCameras().Where(x => x.active && x.connected).ToList();
            Cameras = new ObservableCollection<CameraContract>(contracts);
        }

        public ObservableCollection<CameraContract> Cameras
        {
            get
            {
                return _cameras;
            }
            set
            {

                if (_cameras == null || !_cameras.Equals(value))
                {
                    _cameras = value;
                    OnPropertyChanged("Cameras");
                };
            }
        }

        private string _defaultPath;
        private void GetImage(object _selected)
        {
            var dialog = new OpenFileDialog { InitialDirectory = _defaultPath };
            dialog.ShowDialog();
            SelectedPath = dialog.FileName;
        }
        private bool CanGetImageCommand(object obj)
        {
            return true;
        }


        private CameraContract _selectedCamera;
        public CameraContract SelectedCamera
        {
            get
            {
                return _selectedCamera;
            }
            set
            {
                _selectedCamera = value;
                base.OnPropertyChanged("SelectedItem");
            }
        }

        private void CloseWindow(Object obj)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.CloseGiveAudioWindowViewDialog();
        }

        private bool CanCloseWindow(object obj)
        {
            return true;
        }

        private void Transmit(object obj)
        {
            var postDataBytes = File.ReadAllBytes(SelectedPath);

            var req = (HttpWebRequest)WebRequest.Create(_businessLogic.GetLive(SelectedCamera.id, "media", "audio"));

            req.Method = "POST";
            req.ContentType = SelectedCodec;
            req.Accept = "application/json";
            req.ContentLength = postDataBytes.Length;

            using (var reqStream = req.GetRequestStream())
            {
                reqStream.Write(postDataBytes, 0, postDataBytes.Length);
            }

            var returnValue = "";
            var res = req.GetResponse() as HttpWebResponse;
            using (var rs = res.GetResponseStream())
            using (var sr = new System.IO.StreamReader(rs, Encoding.UTF8))
            {
                returnValue = sr.ReadToEnd();
            }
        }

        private bool CanTransmitCommand(object obj)
        {
            return true;
        }

        public List<string> CodecList
        {
            get
            {
                var list = new List<string>() { "audio/pcmu", "audio/opus" };
                return list;
            }
        }

        private string selectedCodec;
        public string SelectedCodec
        {
            get { return selectedCodec; }
            set { selectedCodec = value; }
        }
    }
}
