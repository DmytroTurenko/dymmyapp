using GalaSoft.MvvmLight.Messaging;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Netwatch.Cams.UI.ViewModels
{

    public class ViewStreamLink
    {
        public string Link { get; set; }
    }

    public class VideoViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public VideoViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login(Properties.user.Default.UseServiceLayer)) return;
            }

            Messenger.Default.Register<ViewStreamLink>
            (
                 this,
                 (action) => LiveStream = action.Link
            );
        }

        private string liveStream;
        public string LiveStream
        {
            get
            {
                return liveStream;
            }
            set
            {
                liveStream = value;
                OnPropertyChanged("LiveStream");
            }
        }
    }
}
