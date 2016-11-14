using DynamicFields.Data.Model;

namespace DynamicFields.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DynamicFields.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DynamicFields.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            if (!context.Posts.Any())
            {
                context.Posts.Add(new Post {Title = "First post"});
                context.Posts.Add(new Post {Title = "Second post"});
                context.Posts.Add(new Post {Title = "Third post"});
                context.SaveChanges();
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
