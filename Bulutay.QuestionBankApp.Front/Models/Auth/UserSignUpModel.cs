namespace Bulutay.QuestionBankApp.Front.Models
{
    public class UserSignUpModel : IModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
