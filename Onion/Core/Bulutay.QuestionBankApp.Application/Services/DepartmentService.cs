using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class DepartmentService : Service<DepartmentCreateDto, DepartmentUpdateDto, DepartmentListDto, Department>, IDepartmentService
    {
        public DepartmentService(IMapper mapper, IValidator<DepartmentCreateDto> createDtoValidator, IValidator<DepartmentUpdateDto> updateDtoValidator, IRepository<Department> repository) : base(mapper, createDtoValidator, updateDtoValidator, repository)
        {

        }
    }
}
