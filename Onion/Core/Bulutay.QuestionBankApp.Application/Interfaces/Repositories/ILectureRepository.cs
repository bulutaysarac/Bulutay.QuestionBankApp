using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface ILectureRepository : IRepository<Lecture>
    {
        Task<List<Lecture>> GetAllWithDepartmentAsync();
        Task<Lecture> GetByIdWithDepartmentAsync(int id);
    }
}
