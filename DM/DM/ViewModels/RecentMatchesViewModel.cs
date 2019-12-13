using DM.DB;
using DM.Help;
using DM.ID_handler;
using DM.JSON;
using DM.REST;
using DM.ViewClasses;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using static DM.App;

namespace DM.ViewModels
{
    class RecentMatchesViewModel
    {
        public RecentMatchesViewModel()
        {
            RestService rest = RestService.Instance;
            RecentMatches = rest.GetPlayerRecentMatches(Id_holder.Instance.Steam32id + "/recentMatches"); ;
            InitializeRecentMatches();
        }
        public List<MatchCropped> RecentMatches { get; set; }
        public ObservableCollection<RecentMatchToDisplay> RecentMacthesToDisplay { get; } = new ObservableCollection<RecentMatchToDisplay>();

        private HeroesDB GetHero(int heroID)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            using (SQLiteConnection db = new SQLiteConnection(dbPath))
            {
                var hero = db.Get<HeroesDB>(heroID);
                return hero;
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
