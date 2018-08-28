using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BakeUpBackendR1.Startup))]
namespace BakeUpBackendR1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
