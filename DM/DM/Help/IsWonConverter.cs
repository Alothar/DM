using DM.JSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class IsWonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var match = (MatchCropped)value;
            var str = new FormattedString();
            if ((match.radiant_win && match.player_slot<=127) || (!match.radiant_win && match.player_slot > 127)) str.Spans.Add(new Span { Text = "Won Match", ForegroundColor = Color.Green });
            else str.Spans.Add(new Span { Text = "Lost Match", ForegroundColor = Color.Red });
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}