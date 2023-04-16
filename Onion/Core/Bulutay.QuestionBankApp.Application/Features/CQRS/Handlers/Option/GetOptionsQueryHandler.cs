using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetOptionsQueryHandler : IRequestHandler<GetOptionsQueryRequest, IResponse<List<OptionListDto>>>
    {
        private readonly IOptionService _optionService;

        public GetOptionsQueryHandler(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public async Task<IResponse<List<OptionListDto>>> Handle(GetOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _optionService.GetAllAsync();
            return response;
        }
    }
}
