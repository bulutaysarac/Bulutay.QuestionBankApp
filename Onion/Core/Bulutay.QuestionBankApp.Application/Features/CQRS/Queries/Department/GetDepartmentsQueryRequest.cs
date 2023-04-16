using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetDepartmentsQueryRequest : IRequest<IResponse<List<DepartmentListDto>>>
    {

    }
}
