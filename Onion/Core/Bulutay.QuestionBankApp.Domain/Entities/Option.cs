namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class Option : BaseEntity
    {
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
