using DM.ID_handler;
using DM.JSON;
using DM.REST;
using System;
using Xamarin.Forms;
using DM.View;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace DM.ViewModels
{
    class WelcomeViewModel
    {
        public WelcomeViewModel(ProfileObject profile)
        {
            Profile = profile;
        }

        public ProfileObject Profile { get; set; }
        public ImageSource Avatar
        {
            get { return ImageSource.FromUri(new Uri(Profile.profile.avatarfull)); }
        }

        public Command ShowRecentMatchesCommand => new Command(ShowRecentMatches);

        private void ShowRecentMatches()
        {
            RestService rest = RestService.Instance;

            List<MatchCropped> recentMatches = rest.GetPlayerRecentMatches(Id_holder.Instance.Steam_32_id + "/recentMatches");
            List<HeroObject> heroes = InitiateHeroes();
            //Navigate to recent matches page
             App.Current.MainPage.Navigation.PushAsync(new RecentMatchesPage(recentMatches, heroes));
            
        }

        private List<HeroObject> InitiateHeroes()
        {
            List<HeroObject> heroes = new List<HeroObject>();
            Stream stream = this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("DM.Resources.Heroes.json");
            StreamReader reader = new StreamReader(stream);
            string textFromFile = reader.ReadToEnd();
            heroes = JsonConvert.DeserializeObject<List<HeroObject>>(textFromFile);
            return heroes;
        }
    }
}
