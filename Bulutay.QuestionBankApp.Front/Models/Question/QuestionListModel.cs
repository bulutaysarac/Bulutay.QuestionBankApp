namespace Bulutay.QuestionBankApp.Front.Models
{
    public class QuestionListModel : IModel
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public CategoryListModel? Category { get; set; }
        public LectureListModel? Lecture { get; set; }
        public UserListModel? User { get; set; }
        public List<OptionListModel>? Options { get; set; } = new List<OptionListModel>();
        public string ShortBody 
        { 
            get => Body != null ? Body.Substring(0, Math.Min(Body.Length, 35)) : ""; 
        }
    }
}
