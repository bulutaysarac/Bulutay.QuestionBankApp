using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Extensions;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;
using System.Data;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class UserService : Service<UserCreateDto, UserUpdateDto, UserListDto, User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<UserCreateDto> _createDtoValidator;
        private readonly IValidator<UserUpdateDto> _updateDtoValidator;
        private readonly IValidator<UserCheckDto> _signInDtoValidator;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        public UserService(IMapper mapper, IValidator<UserCreateDto> createDtoValidator, IValidator<UserUpdateDto> updateDtoValidator, IValidator<UserCheckDto> signInDtoValidator, IUserRepository userRepository, IRepository<UserRole> userRoleRepository) : base(mapper, createDtoValidator, updateDtoValidator, userRepository)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _signInDtoValidator = signInDtoValidator;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IResponse<UserCheckDto>> CheckUserAsync(UserCheckDto dto)
        {
            var validationResult = _signInDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _userRepository.GetByFilterWithRoles(x => x.Username == dto.Username && x.Password == dto.Password);

                if (user == null)
                {
                    return new Response<UserCheckDto>(ResponseType.NotFound, "Username or password is incorrect!");
                }

                if (user.UserRoles != null)
                {
                    foreach (var userRole in user.UserRoles)
                    {
                        if (userRole.Role != null)
                        {
                            dto.Roles.Add(_mapper.Map<RoleListDto>(userRole.Role));
                        }
                    }
                }

                return new Response<UserCheckDto>(ResponseType.Success, dto);
            }

            return new Response<UserCheckDto>("Validation errors occured!", dto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<UserListWithRolesDto>>> GetAllWithRolesAsync()
        {
            var usersWithRoles = await _userRepository.GetAllWithRoles();
            var userListWithRolesDto = new List<UserListWithRolesDto>();

            foreach (var userWithRoles in usersWithRoles)
            {
                var userListWithRoleDto = _mapper.Map<UserListWithRolesDto>(userWithRoles);
                if (userWithRoles.UserRoles != null)
                {
                    foreach (var userRole in userWithRoles.UserRoles)
                    {
                        if (userRole.Role != null)
                        {
                            var role = userRole.Role;
                            userListWithRoleDto.Roles.Add(_mapper.Map<RoleListDto>(role));
                        }
                    }
                }
                userListWithRolesDto.Add(userListWithRoleDto);
            }

            if (userListWithRolesDto.Count > 0)
                return new Response<List<UserListWithRolesDto>>(ResponseType.Success, userListWithRolesDto);
            else
                return new Response<List<UserListWithRolesDto>>(ResponseType.NotFound, "Users table is empty!");
        }

        public async Task<IResponse<UserListWithRolesDto>> GetByIdWithRolesAsync(int id)
        {
            var userWithRole = await _userRepository.GetByIdWithRoles(id);

            if (userWithRole == null)
                return new Response<UserListWithRolesDto>(ResponseType.NotFound, $"User with id {id} is not found!");

            var userListWithRoleDto = _mapper.Map<UserListWithRolesDto>(userWithRole);
            if (userWithRole.UserRoles != null)
            {
                foreach (var userRole in userWithRole.UserRoles)
                {
                    if (userRole.Role != null)
                    {
                        userListWithRoleDto.Roles.Add(_mapper.Map<RoleListDto>(userRole.Role));
                    }
                }
            }

            return new Response<UserListWithRolesDto>(ResponseType.Success, userListWithRoleDto);
        }

        public async Task<IResponse<UserCreateDto>> CreateMemberAsync(UserCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _userRepository.CreateAsMemberAsync(_mapper.Map<User>(dto));
                return new Response<UserCreateDto>(ResponseType.Success, "Member is created!", dto);
            }
            return new Response<UserCreateDto>("Validation errors occured!", dto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse> AddRoleByUserIdAsync(int userId, int roleId)
        {
            await _userRoleRepository.CreateAsync(new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            });
            await _userRoleRepository.CommitAsync();
            return new Response(ResponseType.Success, $"{roleId} role added to user with id {userId}!");
        }

        public async Task<IResponse> RemoveRoleByUserIdAsync(int userId, int roleId)
        {
            var userRole = await _userRoleRepository.GetByFilterAsync(x => x.UserId  == userId && x.RoleId == roleId);
            if(userRole != null)
            {
                _userRoleRepository.Remove(userRole);
            }
            await _userRoleRepository.CommitAsync();
            return new Response(ResponseType.Success, $"{roleId} role removed from user with id {userId}!");
        }

        public async Task<IResponse<List<RoleListDto>>> GetRolesByIdAsync(int userId)
        {
            var data = await _userRepository.GetRolesById(userId);
            if(data == null || data != null && data.Count == 0)
            {
                return new Response<List<RoleListDto>>(ResponseType.NotFound, "User has no roles!");
            }
            var dto = _mapper.Map<List<RoleListDto>>(data);
            return new Response<List<RoleListDto>>(ResponseType.Success, dto);
        }
    }
}
