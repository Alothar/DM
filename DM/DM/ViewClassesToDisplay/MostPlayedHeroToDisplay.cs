using DM.DB;
using DM.JSON;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.ViewClassesToDisplay
{
    class MostPlayedHeroToDisplay
    {
        public MostPlayedHeroToDisplay(MostPlayedHero mpHero, HeroesDB hero)
        {
            this.mpHero = mpHero;
            this.hero = hero;
        }
        public MostPlayedHero mpHero { get; set; }
        public HeroesDB hero { get; set; }
    }
}
