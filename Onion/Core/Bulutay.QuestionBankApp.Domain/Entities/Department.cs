namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string? Definition { get; set; }
        public List<Lecture>? Lectures { get; set; }
    }
}
