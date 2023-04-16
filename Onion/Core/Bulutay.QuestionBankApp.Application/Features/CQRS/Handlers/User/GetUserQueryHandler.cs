using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, IResponse<UserListWithRolesDto>>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IResponse<UserListWithRolesDto>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetByIdWithRolesAsync(request.Id);
            return response;
        }
    }
}
