using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, IResponse<UserCheckDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CheckUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IResponse<UserCheckDto>> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserCheckDto>(request);
            var response = await _userService.CheckUserAsync(dto);
            return response;
        }
    }
}
