using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DressItDB.Startup))]
namespace DressItDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
