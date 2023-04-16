using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class OptionCreateDtoValidator : AbstractValidator<OptionCreateDto>
    {
        public OptionCreateDtoValidator()
        {
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.QuestionId).NotEmpty();
        }
    }
}
