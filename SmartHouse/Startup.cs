using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartHouse.Startup))]
namespace SmartHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
