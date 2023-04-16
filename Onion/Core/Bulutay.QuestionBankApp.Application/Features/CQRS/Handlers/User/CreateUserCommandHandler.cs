using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, IResponse<UserCreateDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IResponse<UserCreateDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var userCreateDto = _mapper.Map<UserCreateDto>(request);
            var userCreateResponse = await _userService.CreateAsync(userCreateDto);
            if(userCreateResponse.ResponseType == ResponseType.Success)
            {
                var userListResponse = await _userService.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
                var user = userListResponse.Data;
                if(request.RoleIds != null && request.RoleIds.Count > 0 && user != null)
                {
                    foreach (int roleId in request.RoleIds)
                    {
                        var roleResponse = await _userService.AddRoleByUserIdAsync(user.Id, roleId);
                    }
                }
            }
            return new Response<UserCreateDto>(ResponseType.Success, "User Created!", userCreateDto);
        }
    }
}
