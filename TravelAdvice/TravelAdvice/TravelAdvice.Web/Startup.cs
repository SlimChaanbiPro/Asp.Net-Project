using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelAdvice.Web.Startup))]
namespace TravelAdvice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
