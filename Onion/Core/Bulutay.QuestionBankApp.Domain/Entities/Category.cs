namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Definition { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
