using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrafegandoInformacoesNaView.Startup))]
namespace TrafegandoInformacoesNaView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
