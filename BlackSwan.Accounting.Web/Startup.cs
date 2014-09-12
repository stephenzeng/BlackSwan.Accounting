using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackSwan.Accounting.Web.Startup))]
namespace BlackSwan.Accounting.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
