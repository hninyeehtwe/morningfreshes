using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MondayAlert.Startup))]
namespace MondayAlert
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
