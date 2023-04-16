using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, IResponse<DepartmentUpdateDto>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<IResponse<DepartmentUpdateDto>> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<DepartmentUpdateDto>(request);
            var response = await _departmentService.UpdateAsync(dto);
            return response;
        }
    }
}
