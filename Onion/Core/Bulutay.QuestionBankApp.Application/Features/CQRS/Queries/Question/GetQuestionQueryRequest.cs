using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Queries
{
    public class GetQuestionQueryRequest : IRequest<IResponse<QuestionListWithCategoryLectureUserDto>>
    {
        public int Id { get; set; }

        public GetQuestionQueryRequest(int id)
        {
            Id = id;
        }
    }
}
