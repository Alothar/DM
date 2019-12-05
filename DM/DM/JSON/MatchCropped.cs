using System;
using System.Collections.Generic;
using System.Text;

namespace DM.JSON
{
    public class MatchCropped
    {
        public object match_id { get; set; }
        public int player_slot { get; set; }
        public bool radiant_win { get; set; }
        public int duration { get; set; }
        public int game_mode { get; set; }
        public int lobby_type { get; set; }
        public int hero_id { get; set; }
        public int start_time { get; set; }
        public int? version { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int? skill { get; set; }
        public int xp_per_min { get; set; }
        public int gold_per_min { get; set; }
        public int hero_damage { get; set; }
        public int tower_damage { get; set; }
        public int hero_healing { get; set; }
        public int last_hits { get; set; }
        public int? lane { get; set; }
        public int? lane_role { get; set; }
        public bool? is_roaming { get; set; }
        public int cluster { get; set; }
        public int leaver_status { get; set; }
        public int? party_size { get; set; }
    }
}
