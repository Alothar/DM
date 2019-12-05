using DM.JSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DM.Help
{
    class RankConverter : IValueConverter
    {

        public int convertmmrtorank(MmrEstimate mmr_estimate)
        {
            int rank;
            if (mmr_estimate.estimate > 0 && mmr_estimate.estimate <= 616) { return 1; }
            else if (mmr_estimate.estimate > 617 && mmr_estimate.estimate <= 1386) { return 2; }
            else if (mmr_estimate.estimate > 1387 && mmr_estimate.estimate <= 2156) { return 3; }
            else if (mmr_estimate.estimate > 2157 && mmr_estimate.estimate <= 2926) { return 4; }
            else if (mmr_estimate.estimate > 2927 && mmr_estimate.estimate <= 3696) { return 5; }
            else if (mmr_estimate.estimate > 3697 && mmr_estimate.estimate <= 4466) { return 6; }
            else if (mmr_estimate.estimate > 4467 && mmr_estimate.estimate <= 5420) { return 7; }
            else if (mmr_estimate.estimate > 5421) { return 8; }
            else rank = 0;

            return rank;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var profile = (ProfileObject)value;
            string path = "";
            
            switch (convertmmrtorank(profile.mmr_estimate))
            {
                case 1:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_1.png";
                    break;
                case 2:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_2.png";
                    break;
                case 3:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_3.png";
                    break;
                case 4:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_4.png";
                    break;
                case 5:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_5.png";
                    break;
                case 6:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_6.png";
                    break;
                case 7:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_7.png";
                    break;
                case 8:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_8.png";
                    break;
                default:
                    path += "DM.Resources.Ranks.app_assets_rank_icons_rank_icon_0.png";
                    break;
            }
            return ImageSource.FromResource(path);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
