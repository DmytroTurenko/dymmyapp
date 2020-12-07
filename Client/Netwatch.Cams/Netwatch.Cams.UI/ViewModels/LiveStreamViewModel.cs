using GalaSoft.MvvmLight.Messaging;
using Netwatch.Cams.BL.Models;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Netwatch.Cams.UI.ViewModels
{
    public class UseServerLayerMessage { }

    public class LiveStreamViewModel : BaseViewModel, INotifyPropertyChanged
    {
        static decimal videoHeight = 300;
        static decimal videoWidth = 250;
        static decimal videoMargin = 50;

        private decimal height = 500;
        public decimal Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        private decimal width = 640;
        public decimal Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }


        private ObservableCollection<CameraContract> _cameras;

        public ICommand CloseCommand { get; set; }
        private DialogueService _dialogueService;
        public ICommand BigScreenCommand { get; set; }

        public LiveStreamViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login()) return;
            }

            CloseCommand = new CustomCommand(CloseWindow, CanCloseWindow);
            BigScreenCommand = new CustomCommand(BigScreen, CanBigScreen);

            LoadCamerasInfo();

            Messenger.Default.Register<UseServerLayerMessage>
            (
                 this,
                 (action) => LoadCamerasInfo()
            );

        }

        private void LoadCamerasInfo()
        {
            var contracts = _businessLogic.GetCameras().Where(x=>x.active && x.connected).ToList();
            foreach(var cam in contracts)
            {
                string curDir = Directory.GetCurrentDirectory();
                cam.liveStream = new Uri(String.Format("{0}/video.html?sid={1}&cid={2}&host={3}&h={4}&w={5}",
                     Properties.user.Default.UseServiceLayer ? ConfigurationManager.AppSettings["serviceLayer"] : $"file:///{curDir}", _businessLogic.GetLoginSessionId(), cam.id, new Uri(ConfigurationManager.AppSettings["baseUrl"]).Authority, 172, 228)).AbsoluteUri;// _businessLogic.GetLive(cam.id, "format", "fmp4");// "rtmp://95.158.55.65/live/test";
            }

            var countInWidth = ((decimal)contracts.Count / 4) > 1 ? 4 : Math.Ceiling((decimal)contracts.Count / 4) == 1 ? 2 : Math.Ceiling((decimal)contracts.Count / 4);
            Width = countInWidth * (videoWidth + videoMargin);
            Height = ((decimal)contracts.Count / 4 == 1 ? 2 : Math.Ceiling((decimal)contracts.Count / 4)) * (videoHeight) + videoMargin;

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

        private void CloseWindow(Object obj)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.CloseLiveStreamWindowViewDialog();
            ((Window)obj).Close();
        }

        private bool CanCloseWindow(object obj)
        {
            return true;
        }

        private void BigScreen(Object obj)
        {
            string curDir = Directory.GetCurrentDirectory();
            var liveStream = new Uri(String.Format("{0}/video.html?sid={1}&cid={2}&host={3}&h={4}&w={5}",
                Properties.user.Default.UseServiceLayer ? ConfigurationManager.AppSettings["serviceLayer"] : $"file:///{curDir}", _businessLogic.GetLoginSessionId(), (string)obj, new Uri(ConfigurationManager.AppSettings["baseUrl"]).Authority, 460, 620)).AbsoluteUri;

            Messenger.Default.Send<ViewStreamLink>(new ViewStreamLink() { Link = liveStream });

            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.ShowVideoWindowViewDialog();
        }

        private bool CanBigScreen(object obj)
        {
            return true;
        }
    }
}