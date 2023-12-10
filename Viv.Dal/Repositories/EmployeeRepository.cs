using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Viv.Dal.Entities;
using Viv.Dal.Context;

namespace Viv.Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly VivDbContext _context;

        public EmployeeRepository(VivDbContext context) 
        {
            _context = context;
        }

        public async Task BatchInsertAsync(IEnumerable<Employee> entities)
        {
            //Using extension library, otherwise would look at adding a range and saving
            await _context.BulkInsertAsync(entities);
        }

        public async Task ClearAllAsync()
        {
            ////I confess I'm not familiar with the best way of clearing a table without pulling records
            ////and removing them, and didn't see an extension that did it. I would consider a TRUNCATE command...
            
            var all = await GetAllAsync();
            _context.Employees.RemoveRange(all);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.Select(x => x).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int companyId, string employeeNumber)
        {
            var employee = await _context.Employees
                .Where(x => x.Company_Id == companyId && x.EmployeeNumber == employeeNumber)
                .Include(x => x.ManagerEmployee)
                .FirstOrDefaultAsync();

            return employee;
        }

        public Task<Employee> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
