using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2.HelloASP.Startup))]
namespace _2.HelloASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
        }
    }
}
