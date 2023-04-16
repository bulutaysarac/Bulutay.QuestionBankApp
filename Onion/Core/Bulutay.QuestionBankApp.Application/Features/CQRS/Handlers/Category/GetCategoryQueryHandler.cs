using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, IResponse<CategoryListDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public GetCategoryQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IResponse<CategoryListDto>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetByIdAsync(request.Id);
            return response;
        }
    }
}
