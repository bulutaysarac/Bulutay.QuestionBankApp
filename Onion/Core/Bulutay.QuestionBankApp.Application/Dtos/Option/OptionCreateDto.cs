namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class OptionCreateDto : IDto
    {
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
