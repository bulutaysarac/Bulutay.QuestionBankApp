using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, IResponse<List<CategoryListDto>>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IResponse<List<CategoryListDto>>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.GetAllAsync();
            return response;
        }
    }
}
