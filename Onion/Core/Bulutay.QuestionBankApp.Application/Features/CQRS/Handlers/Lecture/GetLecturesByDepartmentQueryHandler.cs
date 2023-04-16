using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetLecturesByDepartmentQueryHandler : IRequestHandler<GetLecturesByDepartmenQueryRequest, IResponse<List<LectureListDto>>>
    {
        private readonly ILectureService _lectureService;

        public GetLecturesByDepartmentQueryHandler(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public async Task<IResponse<List<LectureListDto>>> Handle(GetLecturesByDepartmenQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _lectureService.GetAllByDepartmentIdAsync(request.DepartmentId);
            return response;
        }
    }
}
