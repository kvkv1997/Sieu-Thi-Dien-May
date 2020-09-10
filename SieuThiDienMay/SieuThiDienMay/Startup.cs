using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIeuThiDienMay.Startup))]
namespace SIeuThiDienMay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
