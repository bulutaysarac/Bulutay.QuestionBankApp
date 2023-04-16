using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserCheckDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserListWithoutPasswordDto>().ReverseMap();
            CreateMap<UserListWithRolesDto, UserListDto>().ReverseMap();
            CreateMap<UserCreateDto, CreateUserCommandRequest>().ReverseMap();
            CreateMap<UserCreateDto, CreateMemberUserCommandRequest>().ReverseMap();
            CreateMap<UserUpdateDto, UpdateUserCommandRequest>().ReverseMap();
            CreateMap<UserCheckDto, CheckUserQueryRequest>().ReverseMap();
            CreateMap<UserCreateDto, CheckUserQueryRequest>().ReverseMap();
            CreateMap<User, UserListWithRolesDto>().ReverseMap();
        }
    }
}
