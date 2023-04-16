namespace Bulutay.QuestionBankApp.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string? Definition { get; set; }
        public List<UserRole>? UserRoles { get; set; }
    }
}
