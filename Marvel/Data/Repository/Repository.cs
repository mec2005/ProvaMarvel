using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marvel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Data.Repository
{
    public class Repository<T>: IAsyncRepository<T>
        where T: class
    {
        protected readonly MarvelContext _context;

        public Repository(MarvelContext marvelContext)
        {
            _context = marvelContext;
        }

        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id).AsTask();

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            // await _context.AddAsync(entity);
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
