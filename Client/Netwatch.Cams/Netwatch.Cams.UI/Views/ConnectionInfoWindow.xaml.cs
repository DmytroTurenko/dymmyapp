﻿using System;
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
    /// Interaction logic for ConnectionInfoWindow.xaml
    /// </summary>
    public partial class ConnectionInfoWindow : Window
    {
        public ConnectionInfoWindow()
        {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }
    }
}
