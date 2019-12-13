using DM.JSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class WinLoseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var winlose = (WL)value;
            var str = new FormattedString();
            str.Spans.Add(new Span { Text = string.Format("Wins: {0:0} ", winlose.win), ForegroundColor = Color.Green });
            str.Spans.Add(new Span { Text = string.Format("Loses: {0:0}", winlose.lose), ForegroundColor = Color.Red });
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
