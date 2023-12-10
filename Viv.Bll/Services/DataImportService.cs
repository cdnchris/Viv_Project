using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viv.Common.Models;
using Viv.Dal;

namespace Viv.Bll.Services
{
    public abstract class DataImportService : IDataImportService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICompanyRepository _companyRepo;

        public DataImportService(ICompanyRepository companyRepo, IEmployeeRepository employeeRepo) 
        {
            _employeeRepo = employeeRepo;
            _companyRepo = companyRepo;
        }

        public abstract Task ImportDataAsync(byte[] fileData);

        public async virtual Task ClearAllDataAsync()
        {
            await _employeeRepo.ClearAllAsync();
            await _companyRepo.ClearAllAsync();
        }

        protected async virtual Task InsertCompanyData(IEnumerable<CompanyInfo> companies)
        {
            await _companyRepo.BatchInsertAsync(companies);
        }

        protected async virtual Task InsertEmployeeData(IEnumerable<EmployeeInfo> employees) 
        {
            await _employeeRepo.BatchInsertAsync(employees);
        }
    }
}
