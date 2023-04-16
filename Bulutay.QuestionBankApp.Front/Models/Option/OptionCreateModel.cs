namespace Bulutay.QuestionBankApp.Front.Models
{
    public class OptionCreateModel : IModel
    {
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
