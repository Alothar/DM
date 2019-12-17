using System;
using System.Globalization;
using Xamarin.Forms;

namespace DM.Help
{
    class LastPlayedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int dateUnix = (int)value;
            DateTimeOffset dto = new DateTimeOffset(DateTime.Now);
            int dateToday = (int)dto.ToUnixTimeSeconds();
            int dateDiff = dateToday - dateUnix;
            string answer = "";
            if (dateDiff > 300 && dateDiff < 3600)
                answer += string.Format("{0:0} minutes ago", dateDiff / 60);
            else if (dateDiff > 3600 && dateDiff < 7200)
                answer += string.Format("{0:0} hour ago", dateDiff / 3600);
            else if(dateDiff > 7200 && dateDiff < 86400)
                answer += string.Format("{0:0} hours ago", dateDiff / 3600);
            else if (dateDiff > 86400 && dateDiff < 172800)
                answer += string.Format("a day ago", dateDiff / 86400);
            else if (dateDiff > 172800 && dateDiff < 604800)
                answer += string.Format("{0:0} days ago", dateDiff / 86400);
            else if (dateDiff > 604800 && dateDiff < 1209600)
                answer += string.Format("a week ago", dateDiff / 604800);
            else if (dateDiff > 1209600 && dateDiff < 2628000)
                answer += string.Format("{0:0} weeks ago", dateDiff / 604800);
            else if (dateDiff > 2628000 && dateDiff < 5256000)
                answer += string.Format("a month ago", dateDiff / 2628000);
            else if (dateDiff > 2628000 && dateDiff < 31540000)
                answer += string.Format("{0:0} months ago", dateDiff / 2628000);
            else if (dateDiff > 31540000 && dateDiff < 63080000)
                answer += string.Format("a year ago", dateDiff / 31540000);
            else if (dateDiff > 63080000)
                answer += string.Format("{0:0} years ago", dateDiff / 31540000);
            return answer;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
