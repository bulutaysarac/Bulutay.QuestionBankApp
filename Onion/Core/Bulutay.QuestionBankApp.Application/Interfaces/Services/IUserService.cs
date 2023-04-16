using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IUserService : IService<UserCreateDto, UserUpdateDto, UserListDto, User>
    {
        Task<IResponse> AddRoleByUserIdAsync(int userId, int roleId);
        Task<IResponse> RemoveRoleByUserIdAsync(int userId, int roleId);
        Task<IResponse<UserCheckDto>> CheckUserAsync(UserCheckDto dto);
        Task<IResponse<UserCreateDto>> CreateMemberAsync(UserCreateDto dto);
        Task<IResponse<List<UserListWithRolesDto>>> GetAllWithRolesAsync();
        Task<IResponse<UserListWithRolesDto>> GetByIdWithRolesAsync(int id);
    }
}
