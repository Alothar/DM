using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class GameModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "Game mode: ";
            switch ((int)value)
            {
                case 0:
                    result += "Unknown";
                    break;
                case 1:
                    result += "All draft";
                    break;
                case 2:
                    result += "Capitan's mode";
                    break;
                case 3:
                    result += "Random draft";
                    break;
                case 4:
                    result += "Single draft";
                    break;
                case 5:
                    result += "All random";
                    break;
                case 6:
                    result += "Intro";
                    break;
                case 7:
                    result += "Diretide";
                    break;
                case 8:
                    result += "Reverse captain's mode";
                    break;
                case 9:
                    result += "Greeviling";
                    break;
                case 10:
                    result += "Tutorial";
                    break;
                case 11:
                    result += "Mid only";
                    break;
                case 12:
                    result += "Least played";
                    break;
                case 13:
                    result += "Limited heroes";
                    break;
                case 14:
                    result += "Compenduim matchmaking";
                    break;
                case 15:
                    result += "Custom";
                    break;
                case 16:
                    result += "Captain's draft";
                    break;
                case 17:
                    result += "Balanced draft";
                    break;
                case 18:
                    result += "Ability draft";
                    break;
                case 19:
                    result += "Event";
                    break;
                case 20:
                    result += "All random deathmatch";
                    break;
                case 21:
                    result += "1v1 mid";
                    break;
                case 22:
                    result += "All pick";
                    break;
                case 23:
                    result += "Turbo";
                    break;
                default:
                    result += "Mutation";
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
