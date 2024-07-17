using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECAF.Startup))]
namespace ECAF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
