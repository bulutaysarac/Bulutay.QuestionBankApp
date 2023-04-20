using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetRolesByUserQueryHandler : IRequestHandler<GetRolesByUserQueryRequest, IResponse<List<RoleListDto>>>
    {
        private readonly IUserService _userService;

        public GetRolesByUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IResponse<List<RoleListDto>>> Handle(GetRolesByUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.GetRolesByIdAsync(request.UserId);
            return response;
        }
    }
}
