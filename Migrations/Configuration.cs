namespace SEW.Migrations
{
    using System.Data.Entity.Migrations;
    using SEW.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SEWContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SEWContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
