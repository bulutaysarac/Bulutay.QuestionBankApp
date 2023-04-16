using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetDepartmentQueryRequest : IRequest<IResponse<DepartmentListDto>>
    {
        public int Id { get; set; }
        public GetDepartmentQueryRequest(int id)
        {
            Id = id;
        }
    }
}
