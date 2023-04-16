using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class UserCheckDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<RoleListDto> Roles { get; set; } = new List<RoleListDto>();
    }
}
