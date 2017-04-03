using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Codestellar.CatchHash.Startup))]
namespace Codestellar.CatchHash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
