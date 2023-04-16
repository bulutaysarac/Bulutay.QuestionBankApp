namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class RoleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
