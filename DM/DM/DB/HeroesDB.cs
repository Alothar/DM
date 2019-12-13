using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.DB
{
    [Table("Heroes")]
    public class HeroesDB
    {
        [PrimaryKey, Column("ID")]
        public int ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Localized_name")]
        public string Localized_name { get; set; }
        [Column("Primary_attr")]
        public string Primary_attr { get; set; }
        [Column("Attack_type")]
        public string Attack_type { get; set; }
        [Column("Roles")]
        public string Roles { get; set; }
        [Column("Legs")]
        public int Legs { get; set; }
        [Column("Resource")]
        public string Resource { get; set; }
    }
}
