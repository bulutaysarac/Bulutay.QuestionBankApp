namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class UserCreateDto : IDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
