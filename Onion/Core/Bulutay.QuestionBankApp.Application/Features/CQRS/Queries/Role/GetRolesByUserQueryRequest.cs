using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetRolesByUserQueryRequest : IRequest<IResponse<List<RoleListDto>>>
    {
        public int UserId { get; set; }

        public GetRolesByUserQueryRequest(int userId)
        {
            UserId = userId;
        }
    }
}
