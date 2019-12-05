using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class LobbyTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "Lobby type: ";
            switch ((int)value) 
            {
                case 0:
                    result += "Normal";
                    break;
                case 1:
                    result += "Practice";
                    break;
                case 2:
                    result += "Tounament";
                    break;
                case 3:
                    result += "Tutorial";
                    break;
                case 4:
                    result += "Coop bots";
                    break;
                case 5:
                    result += "Ranked team";
                    break;
                case 6:
                    result += "Ranked solo";
                    break;
                case 7:
                    result += "Ranked";
                    break;
                case 8:
                    result += "1v1";
                    break;
                default:
                    result += "Battle cup";
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
