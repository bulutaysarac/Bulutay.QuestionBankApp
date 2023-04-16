using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.ValidationRules
{
    public class QuestionCreateModelValidator : AbstractValidator<QuestionCreateModel>
    {
        public QuestionCreateModelValidator()
        {
            RuleFor(x => x.Body).NotEmpty().WithMessage("Soru metni boş olamaz!");
            RuleFor(x => x.LectureId).NotEmpty().WithMessage("Ders boş olamaz!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori boş olamaz!");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı boş olamaz!");
            RuleFor(x => x.Options).Must(x => x.Count >= 2).When(x => x.CategoryId == 2).WithMessage("En az iki adet seçenek olmalı!");
            RuleForEach(x => x.Options).SetValidator(new OptionOfQuestionValidator()).When(x => x.CategoryId == 2);
        }
    }
}
