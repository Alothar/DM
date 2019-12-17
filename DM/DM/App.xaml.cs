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
using DM.DB;
using DM.MasterPage;

namespace DM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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

        

        public static void InitiateHeroesDB()
        {
            RestService rest = RestService.Instance;
            List<Hero> heroes = rest.GetHeroes();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            using (SQLiteConnection db = new SQLiteConnection(dbPath))
            {
                db.CreateTable<HeroesDB>();
                if (db.Table<HeroesDB>().Count() == 0)
                {
                    // only insert the data if it doesn't already exist
                    foreach (Hero hero in heroes)
                    {
                        var newHero = new HeroesDB
                        {
                            ID = hero.id,
                            Name = hero.name,
                            Localized_name = hero.localized_name,
                            Primary_attr = hero.primary_attr,
                            Attack_type = hero.attack_type,
                            Roles = ""
                        };
                        foreach (string role in hero.roles)
                        {
                            newHero.Roles += role + " ";
                        }
                        newHero.Legs = hero.legs;
                        string[] splittedname = hero.name.Split(new String[] { "o_" }, StringSplitOptions.RemoveEmptyEntries);
                        newHero.Resource = "DM.Resources.Heroes.app_assets_heroes_" + splittedname[splittedname.Length - 1] + "_full.png";
                        db.Insert(newHero);
                    }
                }
            }
        }

        public static void UpdateHeroesDB()
        {
            RestService rest = RestService.Instance;
            List<Hero> heroes = rest.GetHeroes();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "HeroesSQLite.db3");
            using (SQLiteConnection db = new SQLiteConnection(dbPath))
            {
                var dbHeroArray = from hero in db.Table<HeroesDB>()
                                  select hero;
                if (heroes.Count > dbHeroArray.Count())
                    db.DropTable<HeroesDB>();
            }
            InitiateHeroesDB();
        }

    }
}
