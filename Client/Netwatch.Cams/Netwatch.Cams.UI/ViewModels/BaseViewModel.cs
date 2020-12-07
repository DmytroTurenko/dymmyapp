using Netwatch.Cams.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netwatch.Cams.UI.ViewModels
{
    public class BaseViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        protected BusinessLogic _businessLogic;
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="avigilonWebEndpointServiceManager">Avigilon WebEndpoint Service manger to interact with Avigilon WebEndpoint.</param>
        protected BaseViewModel(BusinessLogic businessLogic)
        {
           _businessLogic = businessLogic;
        }
        /// <summary>
        ///  Occurs when a property value changes.
        /// </summary>
        /// <param name="propertyName">The property name in which the value changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }
}
