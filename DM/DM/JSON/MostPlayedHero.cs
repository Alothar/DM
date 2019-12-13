using System;
using System.Collections.Generic;
using System.Text;

namespace DM.JSON
{
    public class MostPlayedHero
    {
        public string hero_id { get; set; }
        public int last_played { get; set; }
        public int games { get; set; }
        public int win { get; set; }
        public int with_games { get; set; }
        public int with_win { get; set; }
        public int against_games { get; set; }
        public int against_win { get; set; }
    }
}
