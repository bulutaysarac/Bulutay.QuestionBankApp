using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class LectureCreateModelValidator : AbstractValidator<LectureCreateModel>
    {
        public LectureCreateModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş olamaz!");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Bölüm boş olamaz!");
        }
    }
}
