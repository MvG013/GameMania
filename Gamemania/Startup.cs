using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamemania.Startup))]
namespace Gamemania
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
