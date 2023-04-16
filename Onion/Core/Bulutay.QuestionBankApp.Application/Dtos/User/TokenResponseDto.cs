namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class TokenResponseDto : IDto
    {
        public TokenResponseDto(string? token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
