using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Viv.Dal.Entities;
using Viv.Dal.Context;
using Viv.Dal.Helpers;
using Viv.Common.Models;

namespace Viv.Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly VivDbContext _context;

        public EmployeeRepository(VivDbContext context) 
        {
            _context = context;
        }

        public async Task BatchInsertAsync(IEnumerable<EmployeeInfo> items)
        {
            //Using extension library, otherwise would look at adding a range and saving
            var entities = items.Select(x => new Employee
            {
                Company_Id = x.Company_Id,
                EmployeeDepartment = x.EmployeeDepartment,
                EmployeeEmail = x.EmployeeEmail,
                EmployeeFirstName = x.EmployeeFirstName,
                EmployeeLastName = x.EmployeeLastName,
                EmployeeNumber = x.EmployeeNumber,
                HireDate = x.HireDate?.ToString(),
                ManagerEmployeeNumber = x.ManagerEmployeeNumber
            });

            await _context.BulkInsertAsync(entities);
        }

        public async Task ClearAllAsync()
        {
            ////I confess I'm not familiar with the best way of clearing a table without pulling records
            ////and removing them, and didn't see an extension that did it. I would consider a TRUNCATE command...
            
            var all = await GetAllEntitiesAsync();
            _context.Employees.RemoveRange(all);
            _context.SaveChanges();
        }

        private async Task<IEnumerable<Employee>> GetAllEntitiesAsync()
        {
            return await _context.Employees.Select(x => x).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeInfo>> GetAllAsync()
        {
            return (await GetAllEntitiesAsync()).Select(x => x.ToEmployeeInfo());
        }

        public async Task<EmployeeInfo> GetByIdAsync(int companyId, string employeeNumber)
        {
            var employee = await _context.Employees
                .Where(x => x.Company_Id == companyId && x.EmployeeNumber == employeeNumber)
                .Include(x => x.ManagerEmployee)
                .FirstOrDefaultAsync();

            return employee?.ToEmployeeInfo(GetManagers(employee));
        }

        public async Task<EmployeeInfo> GetByIdAsync(string id)
        {
            var employee = await _context.Employees
                .Where(x => x.EmployeeNumber == id)
                .FirstOrDefaultAsync();

            return employee?.ToEmployeeInfo();
        }

        private IEnumerable<ManagerInfo> GetManagers(Employee employee, HashSet<Employee> addedEmployees = null)
        {
            List<ManagerInfo> results = new List<ManagerInfo>();
            if (addedEmployees is null)
            {
                //Initial call creates HashSet to track managers, sets initial employee
                addedEmployees = new HashSet<Employee> { employee };
            }
            else
            {
                //First employee is not added
                results.Add(new ManagerInfo
                {
                    EmployeeNumber = employee.EmployeeNumber,
                    FullName = $"{employee.EmployeeFirstName} {employee.EmployeeLastName}"
                });
            }

            if (employee.ManagerEmployee != null && !addedEmployees.Contains(employee.ManagerEmployee))
            {
                var mgr = employee.ManagerEmployee;
                addedEmployees.Add(mgr);
                results.AddRange(GetManagers(mgr, addedEmployees));
            }

            return results;
        }

    }
}
