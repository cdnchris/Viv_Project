using System.Threading.Tasks;
using Viv.Dal.Entities;

namespace Viv.Dal
{
    public interface IEmployeeRepository : IRepository<Employee, string> 
    {
        Task<Employee> GetByIdAsync(int companyId, string employeeNumber);
    }
}
