using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestAppOrders.Startup))]
namespace TestAppOrders
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
