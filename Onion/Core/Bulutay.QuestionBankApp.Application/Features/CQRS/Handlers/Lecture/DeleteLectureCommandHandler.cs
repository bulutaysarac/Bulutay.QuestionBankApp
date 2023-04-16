using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class DeleteLectureCommandHandler : IRequestHandler<DeleteLectureCommandRequest, IResponse>
    {
        private readonly ILectureService _lectureService;

        public DeleteLectureCommandHandler(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public Task<IResponse> Handle(DeleteLectureCommandRequest request, CancellationToken cancellationToken)
        {
            var response = _lectureService.RemoveAsync(request.Id);
            return response;
        }
    }
}
