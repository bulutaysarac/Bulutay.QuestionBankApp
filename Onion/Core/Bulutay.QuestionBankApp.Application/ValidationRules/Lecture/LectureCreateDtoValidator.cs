using Bulutay.QuestionBankApp.Application.Dtos;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.ValidationRules
{
    public class LectureCreateDtoValidator : AbstractValidator<LectureCreateDto>
    {
        public LectureCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
}
