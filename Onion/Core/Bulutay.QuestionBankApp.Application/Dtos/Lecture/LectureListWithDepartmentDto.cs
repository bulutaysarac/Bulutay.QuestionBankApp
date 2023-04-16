namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class LectureListWithDepartmentDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DepartmentListDto? Department { get; set; }
    }
}
