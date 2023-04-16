using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQueryRequest, IResponse<DepartmentListDto>>
    {
        private readonly IDepartmentService _departmentService;

        public GetDepartmentQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IResponse<DepartmentListDto>> Handle(GetDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetByIdAsync(request.Id);
            return response;
        }
    }
}
