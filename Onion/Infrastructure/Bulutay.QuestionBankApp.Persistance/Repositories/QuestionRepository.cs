using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using Bulutay.QuestionBankApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bulutay.QuestionBankApp.Persistance.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly QuestionBankContext _context;
        private readonly IServiceProvider _serviceProvider;

        public QuestionRepository(QuestionBankContext context, IServiceProvider serviceProvider) : base(context)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public Task<List<Question>> GetAllWithCategoryLectureUserAsync()
        {
            return _context.Set<Question>()
                .Include(x => x.Category)
                .Include(x => x.Lecture)
                    .ThenInclude(x => x.Department)
                .Include(x => x.User)
                .Include(x => x.Options).ToListAsync();
        }

        public Task<Question> GetByIdWithCategoryLectureUserAsync(int id)
        {
            return _context.Set<Question>()
                .Where(x => x.Id == id)
                .Include(x => x.Category)
                .Include(x => x.Lecture)
                    .ThenInclude(x => x.Department)
                .Include(x => x.User)
                .Include(x => x.Options).SingleOrDefaultAsync();
        }

        public override async Task<Question?> GetByIdAsync(int id, bool track = false)
        {
            if (track)
                return await _context.Set<Question>().Include(x => x.Options).SingleOrDefaultAsync(x => x.Id == id);
            return await _context.Set<Question>().Include(x => x.Options).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async void Update(Question entity, Question unchanged)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<QuestionBankContext>();

            _context.Entry(unchanged).CurrentValues.SetValues(entity);
            unchanged.Options.Clear();
            foreach (var option in entity.Options)
            {
                unchanged.Options.Add(option);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
