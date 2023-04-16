namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class UserListWithRolesDto : IDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<RoleListDto> Roles { get; set; } = new List<RoleListDto>();
    }
}
