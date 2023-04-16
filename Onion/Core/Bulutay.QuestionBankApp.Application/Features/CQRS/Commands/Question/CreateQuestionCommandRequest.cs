using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Commands
{
    public class CreateQuestionCommandRequest : IRequest<IResponse<QuestionCreateDto>>
    {
        public string? Body { get; set; }
        public bool IsCorrect { get; set; } = false;
        public int CategoryId { get; set; }
        public int LectureId { get; set; }
        public int UserId { get; set; }
        public List<OptionListDto>? Options { get; set; }
    }
}
