using DM.Help;
using DM.JSON;
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
        public RecentMatchesViewModel(List<MatchCropped> recentMatches)
        {
            RecentMatches = recentMatches;
            initializeRecentMatches();
        }
        public List<MatchCropped> RecentMatches { get; set; }
        public ObservableCollection<RecentMatch_to_display> RecentMacthesToDisplay { get; } = new ObservableCollection<RecentMatch_to_display>();

        private HeroesDB getHero(int heroID)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            var db = new SQLiteConnection(dbPath);
            var hero = db.Get<HeroesDB>(heroID);
            return hero;
        }

        private void initializeRecentMatches()
        {
            foreach (MatchCropped match in RecentMatches)
            {
                RecentMacthesToDisplay.Add(new RecentMatch_to_display(match, getHero(match.hero_id)));
            }
        }
    }
}
