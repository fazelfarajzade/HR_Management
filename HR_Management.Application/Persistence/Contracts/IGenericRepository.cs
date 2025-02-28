using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
