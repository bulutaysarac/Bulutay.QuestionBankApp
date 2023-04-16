namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class OptionListDto : IDto
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
