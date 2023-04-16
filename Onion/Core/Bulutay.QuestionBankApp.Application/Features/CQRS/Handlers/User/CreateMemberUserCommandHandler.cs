using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers.User
{
    public class CreateMemberUserCommandHandler : IRequestHandler<CreateMemberUserCommandRequest, IResponse<UserCreateDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateMemberUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IResponse<UserCreateDto>> Handle(CreateMemberUserCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserCreateDto>(request);
            var response = await _userService.CreateMemberAsync(dto);
            return response;
        }
    }
}
