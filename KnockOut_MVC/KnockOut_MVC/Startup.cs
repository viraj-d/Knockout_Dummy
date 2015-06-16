using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockOut_MVC.Startup))]
namespace KnockOut_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
