using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FPT_Traing_System.Startup))]
namespace FPT_Traing_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
