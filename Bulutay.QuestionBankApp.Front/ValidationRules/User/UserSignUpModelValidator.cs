using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class UserSignUpModelValidator : AbstractValidator<UserSignUpModel>
    {
        public UserSignUpModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifreyi onayla boş olamaz!");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler eşleşmeli!");
        }
    }
}
