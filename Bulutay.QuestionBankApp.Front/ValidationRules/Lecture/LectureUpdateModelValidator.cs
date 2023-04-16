using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class LectureUpdateModelValidator : AbstractValidator<LectureUpdateModel>
    {
        public LectureUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş olamaz!");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Bölüm boş olamaz!");
        }
    }
}
