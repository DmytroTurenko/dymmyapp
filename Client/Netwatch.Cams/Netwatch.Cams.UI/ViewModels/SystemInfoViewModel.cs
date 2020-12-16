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
    public class SystemInfoViewModel : BaseViewModel
    {
        private ObservableCollection<CameraContract> _cameras;
        public ICommand CloseCommand { get; set; }
        private DialogueService _dialogueService;


        public SystemInfoViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login(Properties.user.Default.UseServiceLayer)) return;
            }

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

        private void CloseWindow(Object obj)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.CloseSystemInfoWindowViewDialog();
        }

        private bool CanCloseWindow(object obj)
        {
            return true;
        }

    }
}