using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PictoHub.Models;
using System.Linq;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(PictoHub.Startup))]
namespace PictoHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Init();
        }

        /// <summary>
        /// Any initialization functions.
        /// </summary>
        private void Init() {
            //context.
            ApplicationDbContext context = new ApplicationDbContext();

            //creating 3 roles.
            //context.Roles.Add(new IdentityRole { Name = "Admin" });
            //context.Roles.Add(new IdentityRole { Name = "Mod" });
            //context.Roles.Add(new IdentityRole { Name = "Guest" });

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


            //context.SaveChanges();


        }
    }
}
