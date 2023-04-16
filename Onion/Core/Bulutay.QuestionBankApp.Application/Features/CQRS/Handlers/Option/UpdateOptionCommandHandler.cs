using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommandRequest, IResponse<OptionUpdateDto>>
    {
        private readonly IOptionService _optionService;
        private readonly IMapper _mapper;

        public UpdateOptionCommandHandler(IOptionService optionService, IMapper mapper)
        {
            _optionService = optionService;
            _mapper = mapper;
        }

        public async Task<IResponse<OptionUpdateDto>> Handle(UpdateOptionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<OptionUpdateDto>(request);
            var response = await _optionService.UpdateAsync(dto);
            return response;
        }
    }
}
