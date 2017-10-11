using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reverb.Web.Startup))]
namespace Reverb.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
