using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetLectureQueryRequest : IRequest<IResponse<LectureListWithDepartmentDto>>
    {
        public int Id { get; set; }

        public GetLectureQueryRequest(int id)
        {
            Id = id;
        }
    }
}
