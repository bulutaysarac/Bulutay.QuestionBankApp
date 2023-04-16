using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
