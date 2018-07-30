using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaDeMusica.Startup))]
namespace TiendaDeMusica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
