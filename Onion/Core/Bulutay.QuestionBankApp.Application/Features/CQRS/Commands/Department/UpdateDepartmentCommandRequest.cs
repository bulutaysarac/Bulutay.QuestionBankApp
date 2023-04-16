using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class UpdateDepartmentCommandRequest : IRequest<IResponse<DepartmentUpdateDto>>
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
