using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopSmart.Web.MVC.Startup))]
namespace ShopSmart.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
