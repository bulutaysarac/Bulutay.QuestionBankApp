using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetLecturesQueryHandler : IRequestHandler<GetLecturesQueryRequest, IResponse<List<LectureListWithDepartmentDto>>>
    {
        private readonly ILectureService _lectureService;

        public GetLecturesQueryHandler(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        public async Task<IResponse<List<LectureListWithDepartmentDto>>> Handle(GetLecturesQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _lectureService.GetAllWithDepartmentAsync();
            return response;
        }
    }
}
