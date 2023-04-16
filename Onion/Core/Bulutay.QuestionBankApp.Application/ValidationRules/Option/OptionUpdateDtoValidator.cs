using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class OptionUpdateDtoValidator : AbstractValidator<OptionUpdateDto>
    {
        public OptionUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.QuestionId).NotEmpty();
        }
    }
}
