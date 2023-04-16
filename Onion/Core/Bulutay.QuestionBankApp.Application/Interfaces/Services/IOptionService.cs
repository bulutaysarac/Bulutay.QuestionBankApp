using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Interfaces
{
    public interface IOptionService : IService<OptionCreateDto, OptionUpdateDto, OptionListDto, Option>
    {

    }
}
