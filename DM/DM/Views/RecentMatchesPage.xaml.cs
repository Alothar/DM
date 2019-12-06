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
using static DM.App;

namespace DM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentMatchesPage : ContentPage
    {
        public RecentMatchesPage(List<MatchCropped> recentMatches)
        {
            InitializeComponent();
            RecentMatchesViewModel recentMatchesViewModel = new RecentMatchesViewModel(recentMatches);
            BindingContext = recentMatchesViewModel;
        }
    }
}