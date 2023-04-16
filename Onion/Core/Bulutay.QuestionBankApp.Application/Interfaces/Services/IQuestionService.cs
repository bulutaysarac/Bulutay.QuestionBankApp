using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IQuestionService : IService<QuestionCreateDto, QuestionUpdateDto, QuestionListDto, Question>
    {
        Task<IResponse<List<QuestionListWithCategoryLectureUserDto>>> GetAllWithCategoryLectureUserAsync();
        Task<IResponse<QuestionListWithCategoryLectureUserDto>> GetByIdWithCategoryLectureUserAsync(int id);
    }
}
