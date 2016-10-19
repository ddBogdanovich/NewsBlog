using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsBlog2.Startup))]
namespace NewsBlog2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
