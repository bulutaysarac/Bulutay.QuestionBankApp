using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class CategoryService : Service<CategoryCreateDto, CategoryUpdateDto, CategoryListDto, Category>, ICategoryService
    {
        public CategoryService(IMapper mapper, IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryUpdateDto> updateDtoValidator, IRepository<Category> repository) : base(mapper, createDtoValidator, updateDtoValidator, repository)
        {

        }
    }
}
