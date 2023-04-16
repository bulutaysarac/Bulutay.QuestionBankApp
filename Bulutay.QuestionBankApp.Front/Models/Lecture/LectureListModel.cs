namespace Bulutay.QuestionBankApp.Front.Models
{
    public class LectureListModel : IModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DepartmentListModel? Department { get; set; }
    }
}
