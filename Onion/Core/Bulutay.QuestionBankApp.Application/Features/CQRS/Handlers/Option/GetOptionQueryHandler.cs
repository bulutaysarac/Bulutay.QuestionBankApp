using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetOptionQueryHandler : IRequestHandler<GetOptionQueryRequest, IResponse<OptionListDto>>
    {
        private readonly IOptionService _optionService;

        public GetOptionQueryHandler(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public async Task<IResponse<OptionListDto>> Handle(GetOptionQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _optionService.GetByIdAsync(request.Id);
            return response;
        }
    }
}
