using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FazTipster.Startup))]
namespace FazTipster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
