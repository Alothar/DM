using DM.JSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class KDAConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var match = (MatchCropped)value;
            double kda = (match.kills + match.assists)/ (double)match.deaths;
            return string.Format("{0}", Math.Round(kda, 1));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
