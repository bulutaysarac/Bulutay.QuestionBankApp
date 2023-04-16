using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommandRequest, IResponse<OptionCreateDto>>
    {
        private readonly IOptionService _optionService;
        private readonly IMapper _mapper;

        public CreateOptionCommandHandler(IOptionService optionService, IMapper mapper)
        {
            _optionService = optionService;
            _mapper = mapper;
        }

        public async Task<IResponse<OptionCreateDto>> Handle(CreateOptionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<OptionCreateDto>(request);
            var response = await _optionService.CreateAsync(dto);
            return response;
        }
    }
}
