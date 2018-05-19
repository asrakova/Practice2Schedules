using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Школьное_расписание.Startup))]
namespace Школьное_расписание
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
