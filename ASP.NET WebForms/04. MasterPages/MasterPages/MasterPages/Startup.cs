using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterPages.Startup))]
namespace MasterPages
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
