using System;
using System.IO;
using System.Windows;
using Microsoft.Web.WebView2.Core;

namespace Netwatch.Cams.UI.Views
{
    /// <summary>
    /// Interaction logic for LiveStreamWindow.xaml
    /// </summary>
    public partial class LiveStreamWindow : Window
    {
        public LiveStreamWindow()
        {
            InitializeComponent();

            //var link = "rtmp://95.158.55.65/live/test";
            //var vlcLibDirectory = new DirectoryInfo(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            //var options = new string[]
            //{
            //};

            //VLC.SourceProvider.CreatePlayer(vlcLibDirectory, options);
            //VLC.SourceProvider.MediaPlayer.SetMedia(new Uri(link), options);
            //VLC.SourceProvider.MediaPlayer.Play();
        }
    }
}
