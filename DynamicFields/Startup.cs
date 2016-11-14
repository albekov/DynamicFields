using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicFields.Startup))]
namespace DynamicFields
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
