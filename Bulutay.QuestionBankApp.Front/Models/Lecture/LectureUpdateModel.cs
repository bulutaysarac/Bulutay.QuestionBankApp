namespace Bulutay.QuestionBankApp.Front.Models
{
    public class LectureUpdateModel : IModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
