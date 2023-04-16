using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Domain.Entities;
using System.Linq.Expressions;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<ListDto>> GetByIdAsync(int id);
        Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}
