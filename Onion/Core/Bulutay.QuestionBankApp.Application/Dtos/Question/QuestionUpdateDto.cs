namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class QuestionUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int CategoryId { get; set; }
        public int LectureId { get; set; }
        public int UserId { get; set; }
        public List<OptionListDto>? Options { get; set; }
    }
}
