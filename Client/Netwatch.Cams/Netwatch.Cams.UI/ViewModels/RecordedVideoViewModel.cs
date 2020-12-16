using GalaSoft.MvvmLight.Messaging;
using Netwatch.Cams.BL.Models;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Netwatch.Cams.UI.ViewModels
{
    public class RecordedVideoViewModel : BaseViewModel
    {
        private ObservableCollection<CameraContract> _cameras;

        public ICommand GetImageCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        private DialogueService _dialogueService;


        public RecordedVideoViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login(Properties.user.Default.UseServiceLayer)) return;
            }

            GetImageCommand = new CustomCommand(GetImage, CanGetImageCommand);
            CloseCommand = new CustomCommand(CloseWindow, CanCloseWindow);

            LoadCamerasInfo();
        }

        private void LoadCamerasInfo()
        {
            var contracts = _businessLogic.GetCameras();
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

        public string _displayedVideo;
        public string DisplayedVideo
        {
            get
            {
                return _displayedVideo;
            }
            set
            {
                _displayedVideo = value;
                OnPropertyChanged("DisplayedVideo");
            }
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

        private void GetImage(object _selected)
        {
            DisplayedVideo = _businessLogic.GetRecordedVideo(SelectedCamera?.id, $"{StartDate:yyyyMMdd}T{StartTime:hhmmss}.000Z,c", $"P0Y0M0DT{DurationTime.Hours}H{DurationTime.Minutes}M{DurationTime.Seconds}S");
            Messenger.Default.Send<ViewStreamLink>(new ViewStreamLink() { Link = DisplayedVideo });
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.ShowVideoWindowViewDialog();
        }

        private bool CanGetImageCommand(object obj)
        {
            return true;
        }
        private void CloseWindow(Object obj)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.CloseRecordedVideoWindowViewDialog();
        }

        private bool CanCloseWindow(object obj)
        {
            return true;
        }

        private TimeSpan startTime;
        public TimeSpan StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        private DateTime startDate = DateTime.UtcNow;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }
        private TimeSpan durationTime;
        public TimeSpan DurationTime
        {
            get
            {
                return durationTime;
            }
            set
            {
                durationTime = value;
            }
        }
    }


}