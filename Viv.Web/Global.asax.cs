using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Viv.Bll.DependencyInjection;
using Viv.Web.App_Start;
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

            ////Ninject
            //IKernel kernel = new StandardKernel();
            ////var config = GlobalConfiguration.Configuration;

            //try
            //{
            //    kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            //    kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            //    //GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            //    kernel.Load(new WebModule());
            //    kernel.Load(new BusinessModule());
            //}
            //catch
            //{
            //    kernel.Dispose();
            //    throw;
            //}

            //config.DependencyResolver = new NinjectDependencyResolver(kernel);
            //kernel.Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders((IEnumerable<System.Web.Http.Validation.ModelValidatorProvider>)config.Services.GetServices(typeof(ModelValidatorProvider)).Cast<ModelValidatorProvider>()));
            //kernel.Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders(config.Services.GetServices(typeof(ModelValidatorProvider)).Cast<ModelValidatorProvider>()));
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
