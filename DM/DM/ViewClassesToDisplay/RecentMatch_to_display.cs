using DM.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.ViewClasses
{
    class RecentMatch_to_display
    {
        public RecentMatch_to_display(MatchCropped match, HeroObject hero) 
        {
            this.match = match;
            this.hero = hero;
        }
        public MatchCropped match { get; set; }
        public HeroObject hero { get; set; }
    }
}
