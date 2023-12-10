using Ninject;
using Ninject.Modules;
using Viv.Bll.Services;
using Viv.Dal.DependencyInjection;

namespace Viv.Bll.DependencyInjection
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            IKernel kernel = Kernel;

            Bind<ICompanyService>().To<CompanyService>();
            Bind<IDataImportService>().To<CsvImportService>();

            kernel.Load(new DataModule());
        }
    }
}
