using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Bulutay.QuestionBankApp.Front.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddValidationErrorsToModelState(this Controller controller, ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
