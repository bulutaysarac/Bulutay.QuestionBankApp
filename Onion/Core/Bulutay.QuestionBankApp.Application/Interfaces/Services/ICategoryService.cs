using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface ICategoryService : IService<CategoryCreateDto, CategoryUpdateDto, CategoryListDto, Category>
    {

    }
}
