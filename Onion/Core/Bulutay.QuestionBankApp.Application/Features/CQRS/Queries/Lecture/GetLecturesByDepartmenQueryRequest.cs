using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetLecturesByDepartmenQueryRequest : IRequest<IResponse<List<LectureListDto>>>
    {
        public int DepartmentId { get; set; }

        public GetLecturesByDepartmenQueryRequest(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
