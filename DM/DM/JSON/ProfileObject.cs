using System;
using System.Collections.Generic;
using System.Text;

namespace DM.JSON
{
    public class Profile
    {
        public int account_id { get; set; }
        public string personaname { get; set; }
        public string name { get; set; }
        public bool? plus { get; set; }
        public int cheese { get; set; }
        public string steamid { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public string profileurl { get; set; }
        public DateTime? last_login { get; set; }
        public string loccountrycode { get; set; }
        public bool is_contributor { get; set; }
    }

    public class MmrEstimate
    {
        public int? estimate { get; set; }
        public int? stdDev { get; set; }
        public int? n { get; set; }
    }

    public class ProfileObject
    {
        public string tracked_until { get; set; }
        public string solo_competitive_rank { get; set; }
        public string competitive_rank { get; set; }
        public int? rank_tier { get; set; }
        public int? leaderboard_rank { get; set; }
        public MmrEstimate mmr_estimate { get; set; }
        public Profile profile { get; set; }
    }
}
