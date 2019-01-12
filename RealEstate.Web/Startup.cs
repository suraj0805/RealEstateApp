using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealEstate.Web.Startup))]
namespace RealEstate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
