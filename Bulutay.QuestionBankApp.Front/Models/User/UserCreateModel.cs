namespace Bulutay.QuestionBankApp.Front.Models
{
    public class UserCreateModel : IModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<int>? RoleIds { get; set; }
        public List<RoleListModel>? DbRoles { get; set; }
    }
}
