using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viv.Dal
{
    public interface IRepository<T, I> 
        where T : class
    {
        Task InsertAsync(T entity);
        Task BatchInsertAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(I id);
        Task<IEnumerable<T>> GetAllAsync();
        Task ClearAllAsync();
    }
}
