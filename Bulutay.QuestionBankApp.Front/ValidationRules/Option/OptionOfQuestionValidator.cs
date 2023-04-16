using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class OptionOfQuestionValidator : AbstractValidator<OptionListModel>
    {
        public OptionOfQuestionValidator()
        {
            RuleFor(x => x.Body).NotEmpty().WithMessage("İçerik boş olamaz!");
        }
    }
}
