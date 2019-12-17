using DM.ID_handler;
using DM.JSON;
using DM.REST;
using System;
using Xamarin.Forms;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DM.ViewClassesToDisplay;
using DM.DB;
using SQLite;
using DM.ViewClasses;

namespace DM.ViewModels
{
    class ProfileViewModel
    {
        public ProfileViewModel()
        {
            RestService rest = RestService.Instance;
            Profile = rest.GetPlayerInfo(Id_holder.Instance.Steam32id);
            Winloses = rest.GetWLInfo(Id_holder.Instance.Steam32id + "/wl");
            MostPlayedHeroes = rest.GetPlayerMostPlayedHeroes(Id_holder.Instance.Steam32id + "/heroes");
            RecentMatches = rest.GetPlayerRecentMatches(Id_holder.Instance.Steam32id + "/recentMatches"); ;
            InitializeRecentMatches();
            InitializeMostPlayedHeroes();
        }
        public List<MatchCropped> RecentMatches { get; set; }
        public ObservableCollection<RecentMatchToDisplay> RecentMacthesToDisplay { get; } = new ObservableCollection<RecentMatchToDisplay>();

        public ProfileObject Profile { get; set; }
        public ImageSource Avatar
        {
            get { return ImageSource.FromUri(new Uri(Profile.profile.avatarfull)); }
        }

        public WL Winloses { get; set; }

        public List<MostPlayedHero> MostPlayedHeroes { get; set; }

        public ObservableCollection<MostPlayedHeroToDisplay> MostPlayedHeroesToDisplay { get; } = new ObservableCollection<MostPlayedHeroToDisplay>();

        private HeroesDB GetHero(int heroID)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            using (SQLiteConnection db = new SQLiteConnection(dbPath))
            {
                var hero = db.Get<HeroesDB>(heroID);
                return hero;
            }
        }

        private void InitializeMostPlayedHeroes()
        {
            foreach (MostPlayedHero hero in MostPlayedHeroes)
            {
                MostPlayedHeroesToDisplay.Add(new MostPlayedHeroToDisplay(hero, GetHero(Convert.ToInt32(hero.hero_id))));
            }
        }

        private void InitializeRecentMatches()
        {
            foreach (MatchCropped match in RecentMatches)
            {
                RecentMacthesToDisplay.Add(new RecentMatchToDisplay(match, GetHero(match.hero_id)));
            }
        }
    }
}
