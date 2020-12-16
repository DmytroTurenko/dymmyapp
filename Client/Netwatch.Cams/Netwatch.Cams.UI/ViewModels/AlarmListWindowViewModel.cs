using GalaSoft.MvvmLight.Messaging;
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
    public class AlarmListWindowViewModel : BaseViewModel
    {
        private DialogueService _dialogueService;
        public ICommand ConnectionCommand { get; set; }
        public ICommand StreamCommand { get; set; }
        public ICommand AudioCommand { get; set; }
        public ICommand VideoCommand { get; set; }
        public ICommand SystemCommand { get; set; }
        public ICommand ImageCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private ObservableCollection<Models.AlarmModel> _alarms;
        private ObservableCollection<CameraContract> _cameras;

        public AlarmListWindowViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login(Properties.user.Default.UseServiceLayer)) return;
            }

           // _dialogueService = new DialogueService();

            ConnectionCommand = new CustomCommand(ConnectionInfo, CanConnectionInfoCommand);
            CloseCommand = new CustomCommand(Close, CanCloseCommand);
            SystemCommand = new CustomCommand(SystemInfo, CanSystemInfoCommand);
            ImageCommand = new CustomCommand(LiveImage, CanLiveImageCommand);
            StreamCommand = new CustomCommand(LiveStream, CanLiveStreamCommand);
            AudioCommand = new CustomCommand(GiveAudioStream, CanGiveAudioStreamCommand);
            VideoCommand = new CustomCommand(RecordedVideo, CanRecordedVideoCommand);

            LoadAllAlarms();
        }

        private void ConnectionInfo(object _selected)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();

            _dialogueService.ShowConnectionInfoWindowViewDialog();
        }

        private bool CanConnectionInfoCommand(object obj)
        {
            return true;
        }

        private void Close(object _selected)
        {
            //_dialogueService.CloseAlarmWindowViewDialog();
        }

        private bool CanCloseCommand(object obj)
        {
            return true;
        }
        private void SystemInfo(object _selected)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();

            _dialogueService.ShowSystemInfoWindowViewDialog();
        }

        private bool CanSystemInfoCommand(object obj)
        {
            return true;
        }

        private void LiveImage(object _selected)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();

            _dialogueService.ShowLiveImageWindowViewDialog();
        }

        private bool CanLiveImageCommand(object obj)
        {
            return true;
        }

        private void LiveStream(object _selected)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();

            _dialogueService.ShowLiveStreamWindowViewDialog();
        }

        private bool CanLiveStreamCommand(object obj)
        {
            return true;
        }

        private void GiveAudioStream(object _selected)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();

            _dialogueService.ShowGiveAudioWindowViewDialog();
        }

        private bool CanGiveAudioStreamCommand(object obj)
        {
            return true;
        }

        private void RecordedVideo(object _selected)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();

            _dialogueService.ShowRecordedVideoWindowViewDialog();
        }

        private bool CanRecordedVideoCommand(object obj)
        {
            return true;
        }

        public ObservableCollection<Models.AlarmModel> Alarms
        {
            get { return _alarms; }
            set
            {

                if (_alarms == null || !_alarms.Equals(value))
                {
                    _alarms = value;
                    OnPropertyChanged("Alarms");
                };
            }
        }


        public void LoadAllAlarms()
        {
            try
            {
                if (Alarms != null)
                {
                    Alarms.Clear();
                    Alarms = null;
                }
                List<AlarmContract> alarms = _businessLogic.GetAlarms();
                var cameras = _businessLogic.GetCameras();


                List<Models.AlarmModel> alarmModel = new List<Models.AlarmModel>();
                foreach (var alarm in alarms)
                {
                    var camera = cameras.FirstOrDefault(x => x.id == alarm.associatedCameras.First());
                    var events = _businessLogic.GetEvents(alarm.id);
                    if (events == null) continue;
                    foreach (var evt in events)
                    {
                        alarmModel.Add(new Models.AlarmModel
                        {
                            Id = alarm.id,
                            Name = alarm.name,
                            State = alarm.state,
                            IsAssignedToCurrentUser = alarm.isAssignedToCurrentUser,
                            IsNoteRequired = alarm.isNoteRequired,
                            TimeOfMostRecentActivation = evt.time.ToString("G"),
                            Time = evt.time,
                            Type = evt.type,
                            AssociatedCameras = alarm.associatedCameras,
                            Cameras = new List<string>(),
                            MissedTriggers = alarm.missedTriggers,
                            Detail = $"{camera?.name}, EventId {alarm.id}"
                        });
                    }

                }
                Alarms = new ObservableCollection<Models.AlarmModel>(alarmModel.OrderByDescending(x=>x.Time));
            }
            catch (Exception ex)
            {
            }

        }

        public bool UseServiceLayer
        {
            get
            {
                return Properties.user.Default.UseServiceLayer;
            }
            
            set
            {
                Properties.user.Default.UseServiceLayer = value;
                Properties.user.Default.Save();
                _businessLogic.Login(Properties.user.Default.UseServiceLayer);
                Messenger.Default.Send<UseServerLayerMessage>( new UseServerLayerMessage());
            }
        }

    }
}
