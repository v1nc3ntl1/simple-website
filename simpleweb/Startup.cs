using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(simpleweb.Startup))]
namespace simpleweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
