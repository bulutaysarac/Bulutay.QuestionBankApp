namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class UserListDto : IDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
