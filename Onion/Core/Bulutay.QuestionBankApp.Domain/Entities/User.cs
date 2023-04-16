namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<UserRole>? UserRoles { get; set; }
        public List<Question>? Questions { get; set; }
    }
}
