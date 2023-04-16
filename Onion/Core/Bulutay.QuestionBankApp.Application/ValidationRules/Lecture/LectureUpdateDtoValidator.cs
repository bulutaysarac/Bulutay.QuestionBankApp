using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class LectureUpdateDtoValidator : AbstractValidator<LectureUpdateDto>
    {
        public LectureUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
}
