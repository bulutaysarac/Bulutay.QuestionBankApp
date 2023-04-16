namespace Bulutay.QuestionBankApp.Front.Models
{
    public class QuestionCreateModel : IModel
    {
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public int CategoryId { get; set; }
        public int DepartmentId { get; set; }
        public int LectureId { get; set; }
        public int UserId { get; set; }
        public List<OptionListModel>? Options { get; set; } = new List<OptionListModel>();
    }
}
