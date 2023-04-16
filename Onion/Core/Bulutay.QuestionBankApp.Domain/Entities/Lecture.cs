namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class Lecture : BaseEntity
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
