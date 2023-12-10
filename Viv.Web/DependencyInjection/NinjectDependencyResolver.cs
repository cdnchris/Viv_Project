//using Ninject;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http.Dependencies;

//namespace Viv.Web.DependencyInjection
//{
//    public class NinjectDependencyResolver : IDependencyResolver
//    {
//        private IKernel kernel;

//        public NinjectDependencyResolver(IKernel kernelParam)
//        {
//            kernel = kernelParam;
//        }

//        public IDependencyScope BeginScope()
//        {
//            return this;
//        }

//        public void Dispose()
//        {
            
//        }

//        public object GetService(Type serviceType)
//        {
//            return kernel.TryGet(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return kernel.GetAll(serviceType);
//        }
//    }
//}