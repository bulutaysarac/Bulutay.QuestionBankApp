using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.LectureId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
