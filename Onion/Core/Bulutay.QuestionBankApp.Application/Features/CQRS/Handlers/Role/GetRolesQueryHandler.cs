using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, IResponse<List<RoleListDto>>>
    {
        private readonly IRoleService _roleService;

        public GetRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IResponse<List<RoleListDto>>> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _roleService.GetAllAsync();
            return response;
        }
    }
}
