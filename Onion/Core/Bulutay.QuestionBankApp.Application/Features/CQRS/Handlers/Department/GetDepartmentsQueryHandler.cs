using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQueryRequest, IResponse<List<DepartmentListDto>>>
    {
        private readonly IDepartmentService _departmentService;

        public GetDepartmentsQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IResponse<List<DepartmentListDto>>> Handle(GetDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetAllAsync();
            return response;
        }
    }
}
