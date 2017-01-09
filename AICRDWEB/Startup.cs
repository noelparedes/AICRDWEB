using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AICRDWEB.Startup))]
namespace AICRDWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
