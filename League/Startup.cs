using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(League.Startup))]
namespace League
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
