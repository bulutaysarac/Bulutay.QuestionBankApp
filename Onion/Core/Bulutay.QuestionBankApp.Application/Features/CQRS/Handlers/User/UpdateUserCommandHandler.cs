using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, IResponse<UserUpdateDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IResponse<UserUpdateDto>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<UserUpdateDto>(request);
            var userUpdateResponse = await _userService.UpdateAsync(dto);
            if (userUpdateResponse.ResponseType == ResponseType.Success)
            {
                if (request.AddedRoleIds != null && request.AddedRoleIds.Count > 0)
                {
                    foreach (var addedRoleId in request.AddedRoleIds)
                    {
                        await _userService.AddRoleByUserIdAsync(request.Id, addedRoleId);
                    }
                }

                if (request.RemovedRoleIds != null && request.RemovedRoleIds.Count > 0)
                {
                    foreach (var removedRoleId in request.RemovedRoleIds)
                    {
                        await _userService.RemoveRoleByUserIdAsync(request.Id, removedRoleId);
                    }
                }
            }
            return userUpdateResponse;
        }
    }
}
