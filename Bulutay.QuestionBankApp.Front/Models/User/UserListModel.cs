namespace Bulutay.QuestionBankApp.Front.Models
{
    public class UserListModel : IModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<RoleListModel>? Roles { get; set; }
    }
}
