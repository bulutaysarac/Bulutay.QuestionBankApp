namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class DepartmentUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
