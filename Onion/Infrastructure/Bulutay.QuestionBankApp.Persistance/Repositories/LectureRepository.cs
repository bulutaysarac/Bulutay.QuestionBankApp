using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using Bulutay.QuestionBankApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Bulutay.QuestionBankApp.Persistance.Repositories
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        private readonly QuestionBankContext _context;
        public LectureRepository(QuestionBankContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Lecture>> GetAllWithDepartmentAsync()
        {
            return await _context.Set<Lecture>()
                .Include(x => x.Department)
                .ToListAsync();
        }

        public async Task<Lecture> GetByIdWithDepartmentAsync(int id)
        {
            return await _context.Set<Lecture>()
                .Where(x => x.Id == id)
                .Include(x => x.Department)
                .SingleOrDefaultAsync();
        }
    }
}
