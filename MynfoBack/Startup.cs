using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MynfoBack.Startup))]
namespace MynfoBack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
