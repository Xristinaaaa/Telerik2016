using System;
using System.Data.Entity;
using SocialNetwork.Data.Migrations;
using SocialNetwork.Data;
using SocialNetwork.ConsoleClient.Searcher;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkContext, Configuration>());

            Importer.Create(Console.Out).Import();

            DataSearcher.Search(new SocialNetworkService());
        }
    }
}
