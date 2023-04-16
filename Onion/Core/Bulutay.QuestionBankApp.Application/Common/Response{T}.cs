using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;

namespace Bulutay.QuestionBankApp.Application.Common
{
    public class Response<T> : IResponse<T>
    {
        public ResponseType ResponseType { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<CustomValidationError>? ValidationErrors { get; set; }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message;
        }

        public Response(ResponseType responseType, T data)
        {
            ResponseType = responseType;
            Data = data;
        }

        public Response(ResponseType responseType, string message, T data)
        {
            ResponseType = responseType;
            Message = message;
            Data = data;
        }

        public Response(string message, T data, List<CustomValidationError> errors)
        {
            ResponseType = ResponseType.ValidationError;
            Message = message;
            Data = data;
            ValidationErrors = errors;
        }
    }
}
