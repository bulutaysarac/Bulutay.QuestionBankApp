using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class CreateMemberUserCommandRequest : IRequest<IResponse<UserCreateDto>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
