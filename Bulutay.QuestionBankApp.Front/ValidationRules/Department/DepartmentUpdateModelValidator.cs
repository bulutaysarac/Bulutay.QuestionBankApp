using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class DepartmentUpdateModelValidator : AbstractValidator<DepartmentUpdateModel>
    {
        public DepartmentUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım boş olamaz!");
        }
    }
}
