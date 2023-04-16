using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetLectureQueryHandler : IRequestHandler<GetLectureQueryRequest, IResponse<LectureListWithDepartmentDto>>
    {
        private readonly ILectureService _lectureService;

        public GetLectureQueryHandler(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public async Task<IResponse<LectureListWithDepartmentDto>> Handle(GetLectureQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _lectureService.GetByIdWithDepartmentAsync(request.Id);
            return response;
        }
    }
}
