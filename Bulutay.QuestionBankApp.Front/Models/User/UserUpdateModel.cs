namespace Bulutay.QuestionBankApp.Front.Models
{
    public class UserUpdateModel : IModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<RoleListModel>? DbRoles { get; set; }
        public List<int>? OldRoleIds { get; set; }
        public List<int>? NewRoleIds { get; set; }
        public List<int>? AddedRoleIds { get; set; }
        public List<int>? RemovedRoleIds { get; set; }
    }
}
