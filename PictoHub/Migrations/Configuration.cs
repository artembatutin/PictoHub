namespace PictoHub.Migrations
{
    using PictoHub.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PictoHub.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PictoHub.Models.ApplicationDbContext";
        }

        protected override void Seed(PictoHub.Models.ApplicationDbContext context)
        {
            //Populating boards.
            context.Boards.ForEachAsync(b => context.Boards.Remove(b));//not the best.
            List<Board> boards = new List<Board>();
            boards.Add(new Board(0, "General", "Anything general related here.", Models.Hub.HubColor.DARK_PURPLE));
            boards.Add(new Board(1, "Cars", "Any car problems? Talk about it.", Models.Hub.HubColor.MAUVE));
            boards.Add(new Board(2, "Animals", "We all love pets.", Models.Hub.HubColor.YELLOWISH_GREEN));
            boards.Add(new Board(3, "Software", "Geeky but oh well...", Models.Hub.HubColor.GREEN));
            boards.ForEach(b => context.Boards.Add(b));

            context.Roles.AddOrUpdate(r => r.Name, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Guest", Id = "g" });
            context.Roles.AddOrUpdate(r => r.Name, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Moderator", Id = "m" });
            context.Roles.AddOrUpdate(r => r.Name, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Administrator", Id = "a" });

            //if(!context.Users.Any(u => u.UserName )


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
