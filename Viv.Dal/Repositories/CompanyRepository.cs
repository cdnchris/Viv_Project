using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Viv.Dal.Entities;
using Viv.Dal.Context;

namespace Viv.Dal.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly VivDbContext _context;

        public CompanyRepository(VivDbContext context)
        {
            _context = context;
        }

        public async Task BatchInsertAsync(IEnumerable<Company> entities)
        {
            //Using extension library, otherwise would look at adding a range and saving
            await _context.BulkInsertAsync(entities);
        }

        public async Task ClearAllAsync()
        {
            ////I confess I'm not familiar with the best way of clearing a table without pulling records
            ////and removing them, and didn't see an extension that did it. I would consider a TRUNCATE command...

            var all = await GetAllAsync();
            _context.Companies.RemoveRange(all);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies
                .Select(x => x)
                .ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies
                .Where(x => x.Id == id)
                .Include(x => x.Employees)
                .FirstOrDefaultAsync();
        }

        public Task InsertAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
