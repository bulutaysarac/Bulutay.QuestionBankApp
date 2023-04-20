using Bulutay.QuestionBankApp.Domain.Entities;
using System.Linq.Expressions;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllWithRoles();
        Task<User> GetByIdWithRoles(int id);
        Task<User> GetByFilterWithRoles(Expression<Func<User, bool>> filter);
        Task CreateAsMemberAsync(User entity);
        Task<List<Role>> GetRolesById(int userId);
    }
}
