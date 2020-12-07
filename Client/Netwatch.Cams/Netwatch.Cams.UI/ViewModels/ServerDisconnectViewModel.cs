using GalaSoft.MvvmLight.Messaging;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Netwatch.Cams.UI.ViewModels
{
    public class ServerDisconnectViewModel : BaseViewModel, INotifyPropertyChanged
    {

        private DispatcherTimer dispatcherTimer = null;
        private BusinessLogic _businessLogic;
        public ICommand ConnectionCommand { get; set; }
        public ICommand LoadedCommand { get; set; }


        private int seconds;
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                seconds = value;
                OnPropertyChanged("Seconds");
            }
        }

        private bool reConnection = false;
        public bool ReConnection
        {
            get
            {
                return reConnection;
            }

            set
            {
                reConnection = value;
                OnPropertyChanged("ReConnection");
            }
        }

        private bool connection = true;
        public bool Connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
                OnPropertyChanged("Connection");
            }
        }

        public ServerDisconnectViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            Connection = true;
            _businessLogic = businessLogic;
            ConnectionCommand = new CustomCommand(ConnectionInfo, CanConnectionInfoCommand);
            LoadedCommand = new CustomCommand(Loaded, CanLoadedCommand);

            //Messenger.Default.Register<ViewStreamLink>
            //(
            //     this,
            //     (action) => LiveStream = action.Link
            //);
        }
        private void ConnectionInfo(object _selected)
        {
            dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
            Login();
        }

        private bool CanConnectionInfoCommand(object obj)
        {
            return true;
        }

        private void Loaded(object _selected)
        {
            Connection = true;
            Login();
        }

        private bool CanLoadedCommand(object obj)
        {
            return true;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Seconds -=1;
            if (Seconds == 0)
            {
                dispatcherTimer.Tick -= new EventHandler(dispatcherTimer_Tick);
                Login();
            }

        }

        private void Login()
        {
            Connection = true;
            ReConnection = false;

            if (!_businessLogic.IsAuthenticated())
            {
                if (!_businessLogic.Login())
                {
                    Seconds = 10;
                    Connection = false;
                    ReConnection = true;

                    dispatcherTimer = new DispatcherTimer();
                    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Start();
                }
                else
                {
                    var ds = new DialogueService();
                    ds.ShowAlarmWindowViewDialog();
                    ds.CloseServerDisconnectViewDialog();
                }
            }

        }
    }
}
