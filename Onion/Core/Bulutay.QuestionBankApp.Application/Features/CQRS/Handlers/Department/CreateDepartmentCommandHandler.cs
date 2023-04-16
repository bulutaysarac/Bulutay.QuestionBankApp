using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, IResponse<DepartmentCreateDto>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<IResponse<DepartmentCreateDto>> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<DepartmentCreateDto>(request);
            var response = await _departmentService.CreateAsync(dto);
            return response;
        }
    }
}
