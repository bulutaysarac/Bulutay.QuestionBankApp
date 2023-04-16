using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class DepartmentCreateModelValidator : AbstractValidator<DepartmentCreateModel>
    {
        public DepartmentCreateModelValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım boş olamaz!");
        }
    }
}
