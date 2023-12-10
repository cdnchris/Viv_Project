using System.Collections.Generic;
using System.Threading.Tasks;
using Viv.Common.Api;

namespace Viv.Bll
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyHeader>> GetCompaniesAsync();
        Task<Company> GetCompany(int id);
        Task<Employee> GetEmployee(int companyId, string employeeNumber);
    }
}
