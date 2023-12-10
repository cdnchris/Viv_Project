using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viv.Bll.DataTransferObjects;

namespace Viv.Bll
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyHeader>> GetCompaniesAsync();
        Task<CompanyDTO> GetCompany(int id);
        Task<EmployeeDTO> GetEmployee(int companyId, string employeeNumber);
    }
}
