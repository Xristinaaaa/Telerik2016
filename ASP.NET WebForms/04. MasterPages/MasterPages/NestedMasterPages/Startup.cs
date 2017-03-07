using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NestedMasterPages.Startup))]
namespace NestedMasterPages
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
