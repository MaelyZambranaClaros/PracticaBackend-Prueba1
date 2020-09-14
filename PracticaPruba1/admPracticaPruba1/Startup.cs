using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admPracticaPruba1.Startup))]
namespace admPracticaPruba1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
