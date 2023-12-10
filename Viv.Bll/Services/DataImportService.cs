using System.Collections.Generic;
using System.Threading.Tasks;
using Viv.Dal;
using Viv.Dal.Entities;

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

        protected async Task ClearData()
        {
            await _employeeRepo.ClearAllAsync();
            await _companyRepo.ClearAllAsync();
        }

        protected async Task InsertCompanyData(IEnumerable<Company> companies)
        {
            await _companyRepo.BatchInsertAsync(companies);
        }

        protected async Task InsertEmployeeData(IEnumerable<Employee> employees) 
        {
            await _employeeRepo.BatchInsertAsync(employees);
        }
    }
}
