using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessMeal.Startup))]
namespace FitnessMeal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
