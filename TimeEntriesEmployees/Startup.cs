using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeEntriesEmployees.Startup))]
namespace TimeEntriesEmployees
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
