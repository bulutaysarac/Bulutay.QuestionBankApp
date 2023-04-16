using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetUserQueryRequest : IRequest<IResponse<UserListWithRolesDto>>
    {
        public int Id { get; set; }

        public GetUserQueryRequest(int id)
        {
            Id = id;
        }
    }
}
