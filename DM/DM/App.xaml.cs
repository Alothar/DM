using DM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using DM.JSON;
using DM.REST;
using System.Collections.Generic;
using System.Linq;

namespace DM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new XF_LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            UpdateHeroesDB();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

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

        public static void InitiateHeroesDB()
        {
            RestService rest = RestService.Instance;
            List<Hero> heroes = rest.GetHeroes();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<HeroesDB>();
            if (db.Table<HeroesDB>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                foreach (Hero hero in heroes)
                {
                    var newHero = new HeroesDB();
                    newHero.ID = hero.id;
                    newHero.Name = hero.name;
                    newHero.Localized_name = hero.localized_name;
                    newHero.Primary_attr = hero.primary_attr;
                    newHero.Attack_type = hero.attack_type;
                    newHero.Roles = "";
                    foreach (string role in hero.roles)
                    {
                        newHero.Roles += role+" ";
                    }
                    newHero.Legs = hero.legs;
                    string[] splittedname = hero.name.Split(new String[]{ "o_" }, StringSplitOptions.RemoveEmptyEntries);
                    newHero.Resource = "DM.Resources.Heroes.app_assets_heroes_" + splittedname[splittedname.Length-1] + "_full.png";
                    db.Insert(newHero);
                }
            }
        }

        public static void UpdateHeroesDB()
        {
            RestService rest = RestService.Instance;
            List<Hero> heroes = rest.GetHeroes();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            var db = new SQLiteConnection(dbPath);
            var dbHeroArray = from hero in db.Table<HeroesDB>()
                              select hero;
            if (heroes.Count > dbHeroArray.Count())
                db.DropTable<Hero>();
            InitiateHeroesDB();
        }

    }
}
