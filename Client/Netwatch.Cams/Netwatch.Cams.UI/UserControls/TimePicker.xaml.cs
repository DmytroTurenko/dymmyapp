using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Netwatch.Cams.UI.UserControls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        {
            InitializeComponent();
            for (var h=0; h<24; h++)
            {
                hh.Items.Add($"{h:00}");
            }
            for (var m = 0; m < 60; m++)
            {
                mm.Items.Add($"{m:00}");
            }
        }
        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimePicker control = obj as TimePicker;
            var newTime = (TimeSpan)e.NewValue;

            control.Hours = newTime.Hours.ToString("00");
            control.Minutes = newTime.Minutes.ToString("00");
        }


        private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimePicker control = obj as TimePicker;
            control.Value = new TimeSpan(int.Parse(control.Hours), int.Parse(control.Minutes),0);
        }

        public TimeSpan Value
        {
            get { return (TimeSpan)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(TimeSpan), typeof(TimePicker),
        new FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged)));



        public string Hours
        {
            get { return ((int)GetValue(HoursProperty)).ToString(); }
            set { 
                SetValue(HoursProperty, int.Parse(value.ToString()));
            }
        }
        public static readonly DependencyProperty HoursProperty =
        DependencyProperty.Register("Hours", typeof(int), typeof(TimePicker),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));

        public string Minutes
        {
            get { return ((int)GetValue(MinutesProperty)).ToString(); }
            set
            {
                SetValue(MinutesProperty, int.Parse(value.ToString()));
            }
            }
        public static readonly DependencyProperty MinutesProperty =
        DependencyProperty.Register("Minutes", typeof(int), typeof(TimePicker),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));
    }
}