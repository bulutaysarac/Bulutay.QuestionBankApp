using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class CategoryCreateModelValidator : AbstractValidator<CategoryCreateModel>
    {
        public CategoryCreateModelValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım boş olamaz!");
        }
    }
}
