namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class QuestionListDto : IDto
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int CategoryId { get; set; }
        public int LectureId { get; set; }
    }
}
