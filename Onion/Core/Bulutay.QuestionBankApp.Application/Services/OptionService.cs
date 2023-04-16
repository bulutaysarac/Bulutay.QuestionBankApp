using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class OptionService : Service<OptionCreateDto, OptionUpdateDto, OptionListDto, Option>, IOptionService
    {
        public OptionService(IMapper mapper, IValidator<OptionCreateDto> createDtoValidator, IValidator<OptionUpdateDto> updateDtoValidator, IRepository<Option> repository) : base(mapper, createDtoValidator, updateDtoValidator, repository)
        {
        }
    }
}
