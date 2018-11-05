namespace PictoHub.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            //foreach (Board b in context.Boards) {
            //   context.Boards.Remove(b);
            //}
            List<Board> boards = new List<Board>();
            boards.Add(new Board(0, "General", "Anything general related here.", Models.Hub.HubColor.DARK_PURPLE));
            boards.Add(new Board(1, "Cars", "Any car problems? Talk about it.", Models.Hub.HubColor.MAUVE));
            boards.Add(new Board(2, "Animals", "We all love pets.", Models.Hub.HubColor.YELLOWISH_GREEN));
            boards.Add(new Board(3, "Software", "Geeky but oh well...", Models.Hub.HubColor.GREEN));
            boards.ForEach(b => context.Boards.AddOrUpdate(b));

            foreach(IdentityRole r in context.Roles) {
                context.Roles.Remove(r);
            }
            context.Roles.AddOrUpdate(r => r.Name, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Banned", Id = "b" });
            context.Roles.AddOrUpdate(r => r.Name, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Mod", Id = "m" });
            context.Roles.AddOrUpdate(r => r.Name, new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Admin", Id = "a" });

            //assigning users.
            //assigning users.
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if (!context.Users.Any(u => u.UserName == "Mikey")) {
                var user = new ApplicationUser { UserName = "Mikey" };
                manager.Create(user, "123admin");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "William")) {
                var user = new ApplicationUser { UserName = "William" };
                manager.Create(user, "123mod");
                manager.AddToRole(user.Id, "Mod");
            }

            if (!context.Users.Any(u => u.UserName == "Charlie")) {
                var user = new ApplicationUser { UserName = "Charlie" };
                manager.Create(user, "123ban");
                manager.AddToRole(user.Id, "Banned");
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
