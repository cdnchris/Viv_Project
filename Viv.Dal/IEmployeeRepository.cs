using System.Threading.Tasks;
using Viv.Common.Models;

namespace Viv.Dal
{
    public interface IEmployeeRepository : IRepository<EmployeeInfo, string> 
    {
        Task<EmployeeInfo> GetByIdAsync(int companyId, string employeeNumber);
    }
}
