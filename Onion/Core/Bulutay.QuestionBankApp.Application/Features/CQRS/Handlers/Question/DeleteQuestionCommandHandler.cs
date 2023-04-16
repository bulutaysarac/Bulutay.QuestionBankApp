using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommandRequest, IResponse>
    {
        private readonly IQuestionService _questionService;

        public DeleteQuestionCommandHandler(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IResponse> Handle(DeleteQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _questionService.RemoveAsync(request.Id);
            return response;
        }
    }
}
