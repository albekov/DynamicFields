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

            if (!context.User.Any())
            {
                context.User.Add(new User {Login = "admin"});
                context.User.Add(new User {Login = "user1"});
            }
        }
    }
}
