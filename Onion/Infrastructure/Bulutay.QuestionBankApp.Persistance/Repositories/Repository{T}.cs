using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using Bulutay.QuestionBankApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulutay.QuestionBankApp.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly QuestionBankContext _context;
        public Repository(QuestionBankContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool track = false)
        {
            if (track)
                return await _context.Set<T>().SingleOrDefaultAsync(filter);
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public virtual async Task<T?> GetByIdAsync(int id, bool track = false)
        {
            if (track)
                return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
