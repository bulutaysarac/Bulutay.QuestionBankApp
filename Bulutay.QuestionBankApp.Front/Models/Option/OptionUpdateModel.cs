namespace Bulutay.QuestionBankApp.Front.Models
{
    public class OptionUpdateModel : IModel
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
