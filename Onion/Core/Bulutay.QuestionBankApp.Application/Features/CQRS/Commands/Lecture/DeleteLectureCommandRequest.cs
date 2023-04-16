using Bulutay.QuestionBankApp.Application.Common;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class DeleteLectureCommandRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        public DeleteLectureCommandRequest(int id)
        {
            Id = id;
        }
    }
}
