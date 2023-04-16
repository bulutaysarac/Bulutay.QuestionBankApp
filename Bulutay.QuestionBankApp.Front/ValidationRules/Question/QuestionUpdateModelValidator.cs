using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class QuestionUpdateModelValidator : AbstractValidator<QuestionUpdateModel>
    {
        public QuestionUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Body).NotEmpty().WithMessage("Soru metni boş olamaz!");
            RuleFor(x => x.LectureId).NotEmpty().WithMessage("Ders boş olamaz!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori boş olamaz!");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı boş olamaz!");
        }
    }
}
