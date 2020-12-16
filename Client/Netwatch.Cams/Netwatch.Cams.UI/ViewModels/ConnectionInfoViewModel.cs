using Netwatch.Cams.BL.Models;
using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Input;

namespace Netwatch.Cams.UI.ViewModels
{
    public class ConnectionInfoViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        private DialogueService _dialogueService;

        private SiteModel site;
        public SiteModel Site
        {
            get { return site; }
            set { site = value; }
        }

        public string IP
        {
            get
            {
                return new Uri(_businessLogic.apiUrl).Host;
            }
        }

        public string Port
        {
            get
            {
                return new Uri(_businessLogic.apiUrl).Port.ToString();
            }
        }

        public ConnectionInfoViewModel(BusinessLogic businessLogic) : base(businessLogic)
        {
            if (!businessLogic.IsAuthenticated())
            {
                if (!businessLogic.Login(Properties.user.Default.UseServiceLayer)) return;
            }

            CloseCommand = new CustomCommand(CloseWindow, CanCloseWindow);


            LoadSiteInfo();
        }

        private void LoadSiteInfo()
        {
            site = _businessLogic.GetSite().site;
        }

        private void CloseWindow(Object obj)
        {
            if (_dialogueService == null)
                _dialogueService = new DialogueService();
            _dialogueService.CloseConnectionInfoWindowViewDialog();
        }

        private bool CanCloseWindow(object obj)
        {
            return true;
        }
    }
}
