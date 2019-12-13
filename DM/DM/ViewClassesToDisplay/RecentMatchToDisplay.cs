using DM.DB;
using DM.JSON;
using System;
using System.Collections.Generic;
using System.Text;
using static DM.App;

namespace DM.ViewClasses
{
    class RecentMatchToDisplay
    {
        public RecentMatchToDisplay(MatchCropped match, HeroesDB hero) 
        {
            this.match = match;
            this.hero = hero;
        }
        public MatchCropped match { get; set; }
        public HeroesDB hero { get; set; }
    }
}
