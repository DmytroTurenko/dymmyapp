using Netwatch.Cams.BL.Models;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Netwatch.Cams.UI.ViewModels
{
    public class LiveImageViewModel : BaseViewModel
    {
        private ObservableCollection<CameraContract> _cameras;

        public ICommand GetImageCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        private DialogueService _dialogueService;


        public LiveImageViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login()) return;
            }

            GetImageCommand = new CustomCommand(GetImage, CanGetImageCommand);
            CloseCommand = new CustomCommand(CloseWindow, CanCloseWindow);

            LoadCamerasInfo();
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

        public string _displayedImage;
        public string DisplayedImage
        {
            get 
            { 
                return _displayedImage; 
            }
            set
            {
                _displayedImage = value;
                OnPropertyChanged("DisplayedImage");
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
            DisplayedImage = _businessLogic.GetLive(SelectedCamera?.id, "format",  "jpeg");
        }

        private bool CanGetImageCommand(object obj)
        {
            return true;
        }
        private void CloseWindow(Object obj)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.CloseLiveImageWindowViewDialog();
        }

        private bool CanCloseWindow(object obj)
        {
            return true;
        }

    }
}