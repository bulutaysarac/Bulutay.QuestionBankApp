namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class LectureCreateDto : IDto
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
