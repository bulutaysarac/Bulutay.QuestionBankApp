namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class CategoryUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
