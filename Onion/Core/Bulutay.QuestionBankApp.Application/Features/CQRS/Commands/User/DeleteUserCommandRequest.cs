using Bulutay.QuestionBankApp.Application.Common;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class DeleteUserCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }

        public DeleteUserCommandRequest(int id)
        {
            Id = id;
        }
    }
}
