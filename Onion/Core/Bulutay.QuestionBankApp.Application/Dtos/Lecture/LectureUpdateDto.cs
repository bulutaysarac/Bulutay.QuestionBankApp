namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class LectureUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
