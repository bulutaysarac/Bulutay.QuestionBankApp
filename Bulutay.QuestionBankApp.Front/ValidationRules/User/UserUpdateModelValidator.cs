using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class UserUpdateModelValidator : AbstractValidator<UserUpdateModel>
    {
        public UserUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz!");
        }
    }
}
