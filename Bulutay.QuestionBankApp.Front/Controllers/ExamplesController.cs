using Bulutay.QuestionBankApp.Front.HttpRequestHelpers;
using Bulutay.QuestionBankApp.Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    public class ExamplesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExamplesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var questions = await QBRequests.GetAllAsync<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, "");
            return questions == null ? View() : View(questions);
        }
    }
}
