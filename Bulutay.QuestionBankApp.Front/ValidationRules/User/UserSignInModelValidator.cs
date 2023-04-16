using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class UserSignInModelValidator : AbstractValidator<UserSignInModel>
    {
        public UserSignInModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
        }
    }
}
