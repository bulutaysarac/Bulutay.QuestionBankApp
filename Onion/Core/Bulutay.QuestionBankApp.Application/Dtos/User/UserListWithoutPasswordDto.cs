namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class UserListWithoutPasswordDto : IDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
    }
}
