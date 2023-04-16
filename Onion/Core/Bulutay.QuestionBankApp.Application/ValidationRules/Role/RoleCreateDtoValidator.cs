using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class RoleCreateDtoValidator : AbstractValidator<RoleCreateDto>
    {
        public RoleCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
