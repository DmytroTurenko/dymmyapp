using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Netwatch.Cams.UI.Views
{
    /// <summary>
    /// Interaction logic for ServerDisconnect.xaml
    /// </summary>
    public partial class ServerDisconnect : Window
    {
        public ServerDisconnect()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (System.Windows.Application.Current.MainWindow == this)
                System.Windows.Application.Current.Shutdown();
        }
    }
}
