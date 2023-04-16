using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest<IResponse<CategoryCreateDto>>
    {
        public string? Definition { get; set; }
    }
}
