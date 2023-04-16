using Bulutay.QuestionBankApp.Application.Common;
using FluentValidation.Results;

namespace Bulutay.QuestionBankApp.Application.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new List<CustomValidationError>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new CustomValidationError()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            return errors;
        }
    }
}
