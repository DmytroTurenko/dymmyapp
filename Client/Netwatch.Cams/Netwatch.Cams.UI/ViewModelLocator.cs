using Netwatch.Cams.BL.Services;
using Netwatch.Cams.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.UI
{
    public class ViewModelLocator
    {
        static BusinessLogic businessLogic;
        private AlarmListWindowViewModel alarmListWindowViewModel;
        private ConnectionInfoViewModel connectionInfoViewModel;
        private SystemInfoViewModel systemInfoViewModel;
        private LiveImageViewModel liveImageViewModel;
        private LiveStreamViewModel liveStreamViewModel;
        private GiveAudioViewModel giveAudioViewModel;
        private RecordedVideoViewModel recordedVideoViewModel;
        private VideoViewModel videoViewModel;
        private ServerDisconnectViewModel serverDisconnectViewModel;

        public ViewModelLocator()
        {
            if (businessLogic == null)
                businessLogic = new BusinessLogic();
        }

        public AlarmListWindowViewModel AlarmListWindowViewModel
        {
            get
            {
                return alarmListWindowViewModel = new AlarmListWindowViewModel(businessLogic);

            }
            set
            {
                alarmListWindowViewModel = value;
            }
        }

        public ConnectionInfoViewModel ConnectionInfoViewModel
        {
            get
            {
                return connectionInfoViewModel = new ConnectionInfoViewModel(businessLogic);
            }

            set
            {
                connectionInfoViewModel = value;
            }
        }

        public SystemInfoViewModel SystemInfoViewModel
        {
            get
            {
                return systemInfoViewModel = new SystemInfoViewModel(businessLogic); ;
            }

            set
            {
                systemInfoViewModel = value;
            }
        }

        public LiveImageViewModel LiveImageViewModel
        {
            get
            {
                return liveImageViewModel = new LiveImageViewModel(businessLogic);
            }

            set
            {
                liveImageViewModel = value;
            }
        }

        public LiveStreamViewModel LiveStreamViewModel
        {
            get
            {
                return liveStreamViewModel = new LiveStreamViewModel(businessLogic);
            }

            set
            {
                liveStreamViewModel = value;
            }
        }

        public GiveAudioViewModel GiveAudioViewModel
        {
            get
            {
                return giveAudioViewModel = new GiveAudioViewModel(businessLogic);
            }

            set
            {
                giveAudioViewModel = value;
            }
        }

        public RecordedVideoViewModel RecordedVideoViewModel
        {
            get
            {
                return recordedVideoViewModel = new RecordedVideoViewModel(businessLogic);
            }

            set
            {
                recordedVideoViewModel = value;
            }
        }

        public VideoViewModel VideoViewModel
        {
            get
            {
                return videoViewModel = new VideoViewModel(businessLogic);
            }

            set
            {
                videoViewModel = value;
            }
        }

        public ServerDisconnectViewModel ServerDisconnectViewModel
        {
            get
            {
                return serverDisconnectViewModel = new ServerDisconnectViewModel(businessLogic);
            }

            set
            {
                serverDisconnectViewModel = value;
            }
        }
    }
}
