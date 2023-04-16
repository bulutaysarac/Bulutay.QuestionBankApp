using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<IResponse<UserCheckDto>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
