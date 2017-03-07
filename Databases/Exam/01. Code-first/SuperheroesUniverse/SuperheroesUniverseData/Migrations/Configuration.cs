namespace SuperheroesUniverseData.Migrations
{
    using System.Data.Entity.Migrations;
    using SuperheroesUniverse.Data;
    public sealed class Configuration : DbMigrationsConfiguration<SuperheroesUniverseContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SuperheroesUniverseContext context)
        {

        }
    }
}
