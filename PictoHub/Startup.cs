using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PictoHub.Startup))]
namespace PictoHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
