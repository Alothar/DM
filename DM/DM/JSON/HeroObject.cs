using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.JSON
{
    public class HeroObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localized_name { get; set; }
        public string primary_attr { get; set; }
        public string attack_type { get; set; }
        public List<string> roles { get; set; }
        public int legs { get; set; }
        public string hero_avatar { get; set; }
    }
}
