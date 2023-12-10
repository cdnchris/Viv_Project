using Ninject.Modules;
using Ninject.Web.Common;
using Viv.Dal.Context;
using Viv.Dal.Repositories;

namespace Viv.Dal.DependencyInjection
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<VivDbContext>().ToSelf().InRequestScope();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            Bind<ICompanyRepository>().To<CompanyRepository>();
        }
    }
}
