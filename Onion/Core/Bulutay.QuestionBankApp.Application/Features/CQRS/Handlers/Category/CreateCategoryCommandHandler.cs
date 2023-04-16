using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, IResponse<CategoryCreateDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;


        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IResponse<CategoryCreateDto>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<CategoryCreateDto>(request);
            var response = await _categoryService.CreateAsync(dto);
            return response;
        }
    }
}
