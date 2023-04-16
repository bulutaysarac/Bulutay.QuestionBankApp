using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
