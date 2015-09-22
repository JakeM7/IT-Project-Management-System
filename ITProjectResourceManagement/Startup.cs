using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITProjectResourceManagement.Startup))]
namespace ITProjectResourceManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
