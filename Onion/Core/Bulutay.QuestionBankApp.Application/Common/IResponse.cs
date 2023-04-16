using Bulutay.QuestionBankApp.Application.Enums;

namespace Bulutay.QuestionBankApp.Application.Common
{
    public interface IResponse
    {
        ResponseType ResponseType { get; set; }
        string? Message { get; set; }
    }
}
