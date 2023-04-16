using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQueryRequest, IResponse<QuestionListWithCategoryLectureUserDto>>
    {
        private readonly IQuestionService _questionService;

        public GetQuestionQueryHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IResponse<QuestionListWithCategoryLectureUserDto>> Handle(GetQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _questionService.GetByIdWithCategoryLectureUserAsync(request.Id);
            return response;
        }
    }
}
