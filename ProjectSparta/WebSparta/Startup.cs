using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSparta.Startup))]
namespace WebSparta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
