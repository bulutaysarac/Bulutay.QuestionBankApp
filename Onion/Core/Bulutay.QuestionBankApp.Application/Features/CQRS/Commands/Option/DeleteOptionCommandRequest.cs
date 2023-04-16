using Bulutay.QuestionBankApp.Application.Common;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class DeleteOptionCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }

        public DeleteOptionCommandRequest(int id)
        {
            Id = id;
        }
    }
}
