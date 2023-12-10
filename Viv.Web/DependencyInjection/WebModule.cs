using Ninject.Modules;
using Ninject.Web.WebApi.Filter;
using System.Web.Http;

namespace Viv.Web.DependencyInjection
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));
        }
    }
}