using Bulutay.QuestionBankApp.Application.Common;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        public DeleteCategoryCommandRequest(int id)
        {
            Id = id;
        }
    }
}
