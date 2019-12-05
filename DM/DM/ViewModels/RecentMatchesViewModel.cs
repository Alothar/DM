using DM.Help;
using DM.JSON;
using DM.ViewClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace DM.ViewModels
{
    class RecentMatchesViewModel
    {
        public RecentMatchesViewModel(List<MatchCropped> recentMatches, List<HeroObject> heroes)
        {
            RecentMatches = recentMatches;
            HeroObjects = heroes;
            initializeRecentMatches();
        }
        public List<MatchCropped> RecentMatches { get; set; }
        public ObservableCollection<RecentMatch_to_display> RecentMacthesToDisplay { get; } = new ObservableCollection<RecentMatch_to_display>();

        public List<HeroObject> HeroObjects { get; set; }

        private HeroObject getHero(int heroID)
        {
            return HeroObjects.Find((HeroObject h) => { return h.id == heroID; });
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
