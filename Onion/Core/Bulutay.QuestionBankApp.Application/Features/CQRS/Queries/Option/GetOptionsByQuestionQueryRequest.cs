using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetOptionsByQuestionQueryRequest : IRequest<IResponse<List<OptionListDto>>>
    {
        public int QuestionId { get; set; }

        public GetOptionsByQuestionQueryRequest(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
