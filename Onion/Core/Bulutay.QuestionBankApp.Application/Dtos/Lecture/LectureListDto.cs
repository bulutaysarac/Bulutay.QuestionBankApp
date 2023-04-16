namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class LectureListDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
