using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, IResponse>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.RemoveAsync(request.Id);
            return response;
        }
    }
}
