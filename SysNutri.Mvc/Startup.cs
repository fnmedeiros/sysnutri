using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SysNutri.Mvc.Startup))]
namespace SysNutri.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
