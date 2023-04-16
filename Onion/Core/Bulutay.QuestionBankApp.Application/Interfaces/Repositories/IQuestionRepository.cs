using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> GetAllWithCategoryLectureUserAsync();
        Task<Question> GetByIdWithCategoryLectureUserAsync(int id);
    }
}
