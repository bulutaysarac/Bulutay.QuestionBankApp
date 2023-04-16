using Bulutay.QuestionBankApp.Application.Enums;

namespace Bulutay.QuestionBankApp.Application.Common
{
    public class Response : IResponse
    {
        public ResponseType ResponseType { get; set; }
        public string? Message { get; set; }

        public Response(ResponseType responseType, string? message)
        {
            ResponseType = responseType;
            Message = message;
        }
    }
}
