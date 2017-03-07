using Newtonsoft.Json;
using SuperheroesUniverse.ConsoleClient.Models;
using SuperheroesUniverse.Data;
using SuperheroesUniverseData.Migrations;
using SuperheroesUniverseModels;
using SuperheroesUniverseModels.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace SuperheroesUniverse.ConsoleClient
{
    class Startup
    {
        static void Main()
        {
            ImportData();
        }
        private static void ImportData()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperheroesUniverseContext, Configuration>());

            var db = new SuperheroesUniverseContext();
            //db.Planets.Add(new Planet { Name = "Earth" });
            db.SaveChanges();

            //ImportFromJson();
        }

        private static void ImportFromJson()
        {
            var superheroes = new List<Superhero>();

            var file = "sample-data.json";
            var filedata = JsonConvert.DeserializeObject<DataModel>(File.ReadAllText(file));
            var fileSuperheroes = JsonConvert.DeserializeObject<ICollection<Superhero>>(filedata.ToString());
            superheroes.AddRange(fileSuperheroes);
            Console.WriteLine("{0} read.", file);

            var superHeroNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var cityNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var powerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var fractionNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        }
    }
}
