using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class UpdateUserCommandRequest : IRequest<IResponse<UserUpdateDto>>
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public List<int>? RemovedRoleIds { get; set; }
        public List<int>? AddedRoleIds { get; set; }
    }
}
