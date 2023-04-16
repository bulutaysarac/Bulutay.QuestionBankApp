using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, IResponse<QuestionCreateDto>>
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<IResponse<QuestionCreateDto>> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<QuestionCreateDto>(request);
            var response = await _questionService.CreateAsync(dto);
            return response;
        }
    }
}
