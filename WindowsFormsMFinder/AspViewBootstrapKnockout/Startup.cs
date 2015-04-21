using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspViewBootstrapKnockout.Startup))]
namespace AspViewBootstrapKnockout
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
