using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommandRequest, IResponse<QuestionUpdateDto>>
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<IResponse<QuestionUpdateDto>> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<QuestionUpdateDto>(request);
            var response = await _questionService.UpdateAsync(dto);
            return response;
        }
    }
}
