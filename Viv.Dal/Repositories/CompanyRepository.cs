using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Viv.Dal.Entities;
using Viv.Dal.Context;
using Viv.Common.Models;
using Viv.Dal.Helpers;

namespace Viv.Dal.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly VivDbContext _context;

        public CompanyRepository(VivDbContext context)
        {
            _context = context;
        }

        public async Task BatchInsertAsync(IEnumerable<CompanyInfo> items)
        {
            //Using extension library, otherwise would look at adding a range and saving
            var entities = items.Select(x => new Company
            {
                CompanyCode = x.CompanyCode,
                CompanyDescription = x.CompanyDescription,
                Id = x.Id
            });
            await _context.BulkInsertAsync(entities);
        }

        public async Task ClearAllAsync()
        {
            ////I confess I'm not familiar with the best way of clearing a table without pulling records
            ////and removing them, and didn't see an extension that did it. I would consider a TRUNCATE command...

            var all = await GetAllEntitiesAsync();
            _context.Companies.RemoveRange(all);
            _context.SaveChanges();
        }

        private async Task<IEnumerable<Company>> GetAllEntitiesAsync()
        {
            return await _context.Companies
                .Select(x => x)
                .ToListAsync();
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllAsync()
        {
            var results = await GetAllEntitiesAsync();

            return results.Select(x => new CompanyInfo
            {
                Id = x.Id,
                CompanyCode = x.CompanyCode,
                CompanyDescription = x.CompanyDescription,
                EmployeeCount = x.Employees.Count()
            });
        }

        public async Task<CompanyInfo> GetByIdAsync(int id)
        {
            var company = await _context.Companies
                .Where(x => x.Id == id)
                .Include(x => x.Employees)
                .FirstOrDefaultAsync();

            return new CompanyInfo
            {
                CompanyCode = company.CompanyCode,
                CompanyDescription = company.CompanyDescription,
                Id = company.Id,
                Employees = company.Employees.Select(x => x.ToEmployeeInfo())
            };
        }

    }
}
