using DM.JSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class SkillBracketConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var match = (MatchCropped)value;
            int skill;
            if (match.skill == null)
                skill = -1;
            else
            {
                skill = (int)match.skill;
            }
            switch (skill)
            {
                case 1:
                    return "Normal Skill";
                case 2:
                    return "High Skill";
                case 3:
                    return "Very High Skill";
                default:
                    return "Unknown Skill";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
