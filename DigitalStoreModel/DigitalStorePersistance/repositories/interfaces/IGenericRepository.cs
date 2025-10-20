using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalStorePersistance.repositories.interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void AddOne(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
