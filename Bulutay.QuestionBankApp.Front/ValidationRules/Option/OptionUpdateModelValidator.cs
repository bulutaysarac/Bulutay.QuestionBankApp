using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class OptionUpdateModelValidator : AbstractValidator<OptionUpdateModel>
    {
        public OptionUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Body).NotEmpty().WithMessage("İçerik boş olamaz!");
            RuleFor(x => x.QuestionId).NotEmpty().WithMessage("Soru boş olamaz!");
        }
    }
}
