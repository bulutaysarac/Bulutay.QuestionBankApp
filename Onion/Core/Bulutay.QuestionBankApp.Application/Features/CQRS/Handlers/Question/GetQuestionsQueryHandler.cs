using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQueryRequest, IResponse<List<QuestionListWithCategoryLectureUserDto>>>
    {
        private readonly IQuestionService _questionService;

        public GetQuestionsQueryHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IResponse<List<QuestionListWithCategoryLectureUserDto>>> Handle(GetQuestionsQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _questionService.GetAllWithCategoryLectureUserAsync();
            return response;
        }
    }
}
