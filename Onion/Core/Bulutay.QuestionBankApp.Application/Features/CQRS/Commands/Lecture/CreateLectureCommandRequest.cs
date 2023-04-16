using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class CreateLectureCommandRequest : IRequest<IResponse<LectureCreateDto>>
    {
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
