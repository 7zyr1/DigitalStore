using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalStoreModel.Models.Core;
using DigitalStorePersistance.repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalStorePersistance.repositories.implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DigitalStoreDBContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(DigitalStoreDBContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public virtual void AddOne(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
