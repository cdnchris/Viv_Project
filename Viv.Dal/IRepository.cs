using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viv.Dal
{
    public interface IRepository<T, I> 
        where T : class
    {
        Task BatchInsertAsync(IEnumerable<T> items);
        Task<T> GetByIdAsync(I id);
        Task<IEnumerable<T>> GetAllAsync();
        Task ClearAllAsync();
    }
}
