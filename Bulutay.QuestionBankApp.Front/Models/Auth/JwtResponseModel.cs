namespace Bulutay.QuestionBankApp.Front.Models
{
    public class JwtResponseModel : IModel
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
