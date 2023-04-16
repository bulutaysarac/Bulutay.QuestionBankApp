using Bulutay.QuestionBankApp.Domain.Entities;
using System.Linq.Expressions;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(int id, bool track = false);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool track = false);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
        void Remove(T entity);
        Task CommitAsync();
    }
}
