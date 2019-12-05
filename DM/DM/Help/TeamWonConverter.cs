using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class TeamWonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = new FormattedString();
            if ((bool)value) str.Spans.Add(new Span { Text = "Radiant win", ForegroundColor = Color.Green});
            else str.Spans.Add(new Span { Text = "Dire win", ForegroundColor = Color.Red});
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
