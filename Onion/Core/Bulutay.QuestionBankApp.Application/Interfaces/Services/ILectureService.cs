using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface ILectureService : IService<LectureCreateDto, LectureUpdateDto, LectureListDto, Lecture>
    {
        Task<IResponse<List<LectureListWithDepartmentDto>>> GetAllWithDepartmentAsync();
        Task<IResponse<LectureListWithDepartmentDto>> GetByIdWithDepartmentAsync(int id);
        Task<IResponse<List<LectureListDto>>> GetAllByDepartmentIdAsync(int departmentId);
    }
}
