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
    public partial class DurationPicker : UserControl
    {
        public DurationPicker()
        {
            InitializeComponent();
            for (var h=0; h<24; h++)
            {
                hh.Items.Add($"{h:00}");
            }
            foreach(var m in new string[]{ "seconds", "minutes","hours"})
            {
                mm.Items.Add(m);
            }
        }
        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            DurationPicker control = obj as DurationPicker;
            var newTime = (TimeSpan)e.NewValue;

            //control.Count = newTime.Hours.ToString("00");
            //control.Minutes = newTime.Minutes.ToString("00");
        }


        private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            DurationPicker control = obj as DurationPicker;
            switch (control.Types)
            {
                case "seconds":
                    control.Value = new TimeSpan(0,0,int.Parse(control.Count));
                    break;
                case "minutes":
                    control.Value = new TimeSpan(0,  int.Parse(control.Count), 0);
                    break;
                case "hours":
                    control.Value = new TimeSpan(int.Parse(control.Count), 0,0);
                    break;
            }

        }

        public TimeSpan Value
        {
            get { return (TimeSpan)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(TimeSpan), typeof(DurationPicker),
        new FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged)));



        public string Count
        {
            get { return ((int)GetValue(CountProperty)).ToString(); }
            set { 
                SetValue(CountProperty, int.Parse(value.ToString()));
            }
        }
        public static readonly DependencyProperty CountProperty =
        DependencyProperty.Register("Count", typeof(int), typeof(DurationPicker),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));

        public string Types
        {
            get { return (string)GetValue(TypesProperty); }
            set
            {
                SetValue(TypesProperty, value);
            }
            }
        public static readonly DependencyProperty TypesProperty =
        DependencyProperty.Register("Types", typeof(string), typeof(DurationPicker),
        new FrameworkPropertyMetadata("seconds", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));
    }
}