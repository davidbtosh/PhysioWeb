using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhysioQA.Startup))]
namespace PhysioQA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
