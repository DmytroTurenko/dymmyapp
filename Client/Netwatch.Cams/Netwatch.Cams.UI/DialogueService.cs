using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Netwatch.Cams.UI
{
    public class DialogueService
    {
        static Window alarmWindowView = null;
        static Window conInfoWindowView = null;
        static Window sysInfoWindowView = null;
        static Window liveImageWindow = null;
        static Window liveStreamWindow = null;
        static Window giveAudioWindow = null;
        static Window recordedVideoWindow = null;
        static Window videoWindow = null;
        static Window serverDisconnect = null;

        public DialogueService()
        {
            if (alarmWindowView == null)
            {
                alarmWindowView = new Views.AlarmListWindow();
                alarmWindowView.Closing += AlarmWindowView_Closing;
            }

            if (conInfoWindowView == null)
            {
                conInfoWindowView = new Views.ConnectionInfoWindow() { ResizeMode = ResizeMode.NoResize };
                conInfoWindowView.Closing += ConnectionInfoWindowView_Closing;
            }

            if (sysInfoWindowView == null)
            {
                sysInfoWindowView = new Views.SystemInfoWindow() { ResizeMode = ResizeMode.NoResize };
                sysInfoWindowView.Closing += SystemInfoWindowView_Closing;
            }

            if (liveImageWindow == null)
            {
                liveImageWindow = new Views.LiveImageWindow() { ResizeMode = ResizeMode.NoResize };
                liveImageWindow.Closing += LiveImageWindowView_Closing;
            }

            if (liveStreamWindow == null)
            {
                liveStreamWindow = new Views.LiveStreamWindow() { ResizeMode = ResizeMode.NoResize };
                liveStreamWindow.Closing += LiveStreamWindowView_Closing;
            }

            if (giveAudioWindow == null)
            {
                giveAudioWindow = new Views.GiveAudioWindow() { ResizeMode = ResizeMode.NoResize };
                giveAudioWindow.Closing += GiveAudioWindowView_Closing;
            }

            if (recordedVideoWindow == null)
            {
                recordedVideoWindow = new Views.RecordedVideoWindow() { ResizeMode = ResizeMode.NoResize };
                recordedVideoWindow.Closing += RecordedVideoWindowView_Closing;
            }

            if (videoWindow == null)
            {
                videoWindow = new Views.VIdeoVIew { ResizeMode = ResizeMode.NoResize };
                videoWindow.Closing += VideoWindowView_Closing;
            }

            if (serverDisconnect == null)
            {
                serverDisconnect = new Views.ServerDisconnect { ResizeMode = ResizeMode.NoResize };
                serverDisconnect.Closing += ServerDisconnectView_Closing;
            }

        }
        public void ShowAlarmWindowViewDialog()
        {
            if (alarmWindowView != null)
            {
                Application.Current.MainWindow = alarmWindowView;
                alarmWindowView.Show();
            }
        }

        public void CloseAlarmWindowViewDialog()
        {
            if (alarmWindowView != null)
                alarmWindowView.Visibility = Visibility.Hidden;
        }

        public void ShowConnectionInfoWindowViewDialog()
        {
            if (conInfoWindowView != null)
                conInfoWindowView.ShowDialog();
        }

        public void CloseConnectionInfoWindowViewDialog()
        {
            if (conInfoWindowView != null)
                conInfoWindowView.Visibility = Visibility.Hidden;
        }

        public void ShowSystemInfoWindowViewDialog()
        {
            if (sysInfoWindowView != null)
                sysInfoWindowView.ShowDialog();
        }

        public void CloseSystemInfoWindowViewDialog()
        {
            if (sysInfoWindowView != null)
                sysInfoWindowView.Visibility = Visibility.Hidden;
        }

        public void ShowLiveImageWindowViewDialog()
        {
            if (liveImageWindow != null)
                liveImageWindow.ShowDialog();
        }

        public void CloseLiveImageWindowViewDialog()
        {
            if (liveImageWindow != null)
                liveImageWindow.Visibility = Visibility.Hidden;
        }

        public void ShowLiveStreamWindowViewDialog()
        {
            if (liveStreamWindow != null)
                liveStreamWindow.ShowDialog();
        }

        public void CloseLiveStreamWindowViewDialog()
        {
            if (liveStreamWindow != null)
                liveStreamWindow.Visibility = Visibility.Hidden;
        }

        public void ShowGiveAudioWindowViewDialog()
        {
            if (giveAudioWindow != null)
                giveAudioWindow.ShowDialog();
        }

        public void CloseGiveAudioWindowViewDialog()
        {
            if (giveAudioWindow != null)
                giveAudioWindow.Visibility = Visibility.Hidden;
        }

        public void ShowRecordedVideoWindowViewDialog()
        {
            if (recordedVideoWindow != null)
                recordedVideoWindow.ShowDialog();
        }

        public void CloseRecordedVideoWindowViewDialog()
        {
            if (recordedVideoWindow != null)
                recordedVideoWindow.Visibility = Visibility.Hidden;
        }

        public void ShowVideoWindowViewDialog()
        {
            if (videoWindow != null)
                videoWindow.ShowDialog();
        }

        public void CloseVideoWindowViewDialog()
        {
            if (videoWindow != null)
                videoWindow.Visibility = Visibility.Hidden;
        }

        public void ShowServerDisconnectViewDialog()
        {
            if (serverDisconnect != null)
                serverDisconnect.ShowDialog();
        }

        public void CloseServerDisconnectViewDialog()
        {
            if (serverDisconnect != null)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is Views.ServerDisconnect)
                    {
                        window.Close();
                        break;
                    }
                }
            }
        }

        void AlarmWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (alarmWindowView != null)
            {
                e.Cancel = true;
                alarmWindowView.Visibility = Visibility.Hidden;
            }
        }
        void ConnectionInfoWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (conInfoWindowView != null)
            {
                e.Cancel = true;
                conInfoWindowView.Visibility = Visibility.Hidden;
            }
        }
        void SystemInfoWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sysInfoWindowView != null)
            {
                e.Cancel = true;
                sysInfoWindowView.Visibility = Visibility.Hidden;
            }
        }

        void LiveImageWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (liveImageWindow != null)
            {
                e.Cancel = true;
                liveImageWindow.Visibility = Visibility.Hidden;
            }
        }

        void LiveStreamWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (liveStreamWindow != null)
            {
                e.Cancel = true;
                liveStreamWindow.Visibility = Visibility.Hidden;
            }
        }

        void GiveAudioWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (giveAudioWindow != null)
            {
                e.Cancel = true;
                giveAudioWindow.Visibility = Visibility.Hidden;
            }
        }

        void RecordedVideoWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (recordedVideoWindow != null)
            {
                e.Cancel = true;
                recordedVideoWindow.Visibility = Visibility.Hidden;
            }
        }

        void VideoWindowView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (videoWindow != null)
            {
                e.Cancel = true;
                videoWindow.Visibility = Visibility.Hidden;
            }
        }

        void ServerDisconnectView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (serverDisconnect != null)
            {
                e.Cancel = true;
                serverDisconnect.Visibility = Visibility.Hidden;
            }
        }
    }
}
