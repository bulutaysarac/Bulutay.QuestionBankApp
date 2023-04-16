using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, IResponse<CategoryUpdateDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IResponse<CategoryUpdateDto>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.UpdateAsync(_mapper.Map<CategoryUpdateDto>(request));
            return response;
        }
    }
}
