using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers.Option
{
    public class GetOptionsByQuestionQueryHandler : IRequestHandler<GetOptionsByQuestionQueryRequest, IResponse<List<OptionListDto>>>
    {
        private readonly IOptionService _optionService;

        public GetOptionsByQuestionQueryHandler(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public Task<IResponse<List<OptionListDto>>> Handle(GetOptionsByQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _optionService.GetAllAsync(x => x.QuestionId == request.QuestionId);
            return response;
        }
    }
}
