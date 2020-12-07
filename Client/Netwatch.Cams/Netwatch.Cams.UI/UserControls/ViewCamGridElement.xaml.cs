using GalaSoft.MvvmLight.Messaging;
using Netwatch.Cams.BL.Models;
using Netwatch.Cams.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Netwatch.Cams.UI.UserControls
{
    /// <summary>
    /// Interaction logic for ViewCamGridElement.xaml
    /// </summary>
    public partial class ViewCamGridElement : UserControl
    {
        public ViewCamGridElement()
        {
            InitializeComponent();
        }

        public CameraContract Camera
        {
            get { return ((CameraContract)GetValue(CameraContractProperty)); }
            set
            {
                SetValue(CameraContractProperty, value);
            }
        }
        public static readonly DependencyProperty CameraContractProperty =
        DependencyProperty.Register("Camera", typeof(CameraContract), typeof(ViewCamGridElement),
        new FrameworkPropertyMetadata(new CameraContract(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCameraChanged)));

        private static void OnCameraChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var view = obj as ViewCamGridElement;
            view.Title.Text = view.Camera.name;
            view.webView.Source = new Uri(view.Camera.liveStream);
            if (!view.Camera.connected)
            {
                view.webView.Visibility = Visibility.Collapsed;
                view.bigButton.Visibility = Visibility.Collapsed;
                view.disconnectBorder.Visibility = Visibility.Visible;
            }
        }

        public ICommand BigScreenCommand
        {
            get { return ((ICommand)GetValue(BigScreenCommandProperty)); }
            set
            {
                SetValue(BigScreenCommandProperty, value);
            }
        }
        public static readonly DependencyProperty BigScreenCommandProperty =
        DependencyProperty.Register("BigScreenCommand", typeof(ICommand), typeof(ViewCamGridElement),
        new UIPropertyMetadata(null));
    }
}
