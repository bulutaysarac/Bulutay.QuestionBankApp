namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int LectureId { get; set; }
        public Lecture? Lecture { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Option>? Options { get; set; }
    }
}
