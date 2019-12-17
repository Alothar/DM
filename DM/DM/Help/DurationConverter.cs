using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0:0}:{1:00}:{2:00}", (int)value/3600, ((int)value/60)%60, (int)value%60);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String[] stringarr = ((string)value).Split(':');
            TimeSpan duration = new TimeSpan(System.Convert.ToInt32(stringarr[0]), System.Convert.ToInt32(stringarr[1]), System.Convert.ToInt32(stringarr[2]));
            return duration.Seconds;
        }
    }
}
