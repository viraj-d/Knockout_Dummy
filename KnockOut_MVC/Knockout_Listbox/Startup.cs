using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Knockout_Listbox.Startup))]
namespace Knockout_Listbox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
