using Bulutay.QuestionBankApp.Application.Common;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class DeleteDepartmentCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommandRequest(int id)
        {
            Id = id;
        }
    }
}
