using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class CreateUserCommandRequest : IRequest<IResponse<UserCreateDto>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<int>? RoleIds { get; set; }
    }
}
