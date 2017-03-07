namespace SocialNetwork.Data.Migrations
{
    using System.Data.Entity.Migrations;
    public sealed class Configuration : DbMigrationsConfiguration<SocialNetworkContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SocialNetworkContext context)
        {

        }
    }
}
