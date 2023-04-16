using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetOptionQueryRequest : IRequest<IResponse<OptionListDto>>
    {
        public int Id { get; set; }

        public GetOptionQueryRequest(int id)
        {
            Id = id;
        }
    }
}
