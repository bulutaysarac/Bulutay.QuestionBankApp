namespace Bulutay.QuestionBankApp.Front.Models
{
    public class RoleListModel : IModel
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public bool IsSelected { get; set; }
    }
}
