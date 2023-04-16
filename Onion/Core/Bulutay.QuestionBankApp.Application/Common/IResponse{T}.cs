using Bulutay.QuestionBankApp.Application.Enums;

namespace Bulutay.QuestionBankApp.Application.Common
{
    public interface IResponse<T> : IResponse
    {
        T? Data { get; set; }
        List<CustomValidationError>? ValidationErrors { get; set; }
    }
}
