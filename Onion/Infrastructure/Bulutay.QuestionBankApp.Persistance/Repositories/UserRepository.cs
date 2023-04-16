using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using Bulutay.QuestionBankApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulutay.QuestionBankApp.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly QuestionBankContext _context;
        public UserRepository(QuestionBankContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllWithRoles()
        {
            return await _context.Set<User>()
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync();
        }

        public async Task<User> GetByIdWithRoles(int id)
        {
            return await _context.Set<User>()
                .Where(x => x.Id == id)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetByFilterWithRoles(Expression<Func<User, bool>> filter)
        {
            return await _context.Set<User>()
                .Where(filter)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .SingleOrDefaultAsync();
        }

        public async Task CreateAsMemberAsync(User entity)
        {
            entity.UserRoles = new List<UserRole> { new UserRole() { RoleId = (int)RoleType.Member } };
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
