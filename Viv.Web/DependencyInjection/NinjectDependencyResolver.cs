using Ninject;
using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Viv.Bll.DependencyInjection;

namespace Viv.Web.DependencyInjection
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel) : base(kernel) 
        {
            _kernel = kernel;
            Bind();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel);
        }

        private void Bind()
        {
            _kernel.Load(new WebModule());
            _kernel.Load(new BusinessModule());
        }
    }
}