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
    /// Interaction logic for AlarmListWindow.xaml
    /// </summary>
    public partial class AlarmListWindow : Window
    {
        public AlarmListWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            System.Windows.Application.Current.Shutdown();
        }
    }
}
