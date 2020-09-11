using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SieuThiDienMay.Startup))]
namespace SieuThiDienMay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
