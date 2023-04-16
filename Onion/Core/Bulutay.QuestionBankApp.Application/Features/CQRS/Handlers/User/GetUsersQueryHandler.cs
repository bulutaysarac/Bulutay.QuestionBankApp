using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, IResponse<List<UserListWithRolesDto>>>
    {
        private readonly IUserService _userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IResponse<List<UserListWithRolesDto>>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetAllWithRolesAsync();
            return response;
        }
    }
}
