using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class RoleService : Service<RoleCreateDto, RoleUpdateDto, RoleListDto, Role>, IRoleService
    {
        public RoleService(IMapper mapper, IValidator<RoleCreateDto> createDtoValidator, IValidator<RoleUpdateDto> updateDtoValidator, IRepository<Role> repository) : base(mapper, createDtoValidator, updateDtoValidator, repository)
        {

        }
    }
}
