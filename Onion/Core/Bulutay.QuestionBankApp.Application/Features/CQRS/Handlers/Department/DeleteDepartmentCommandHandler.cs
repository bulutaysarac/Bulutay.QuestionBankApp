using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommandRequest, IResponse>
    {
        private readonly IDepartmentService _departmentService;

        public DeleteDepartmentCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public Task<IResponse> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var response = _departmentService.RemoveAsync(request.Id);
            return response;
        }
    }
}
