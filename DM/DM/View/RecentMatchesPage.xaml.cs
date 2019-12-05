using DM.JSON;
using DM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentMatchesPage : ContentPage
    {
        public RecentMatchesPage(List<MatchCropped> recentMatches, List<HeroObject> heroes)
        {
            InitializeComponent();
            RecentMatchesViewModel recentMatchesViewModel = new RecentMatchesViewModel(recentMatches, heroes);
            BindingContext = recentMatchesViewModel;
        }
    }
}