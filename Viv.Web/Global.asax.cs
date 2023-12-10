using Ninject;
using Ninject.Web.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Viv.Web.DependencyInjection;

namespace Viv.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Ninject
            IKernel kernel = new StandardKernel();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
            //kernel.Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders(config.Services.GetServices(typeof(ModelValidatorProvider)).Cast<ModelValidatorProvider>()));
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
