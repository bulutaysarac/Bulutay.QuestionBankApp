using Microsoft.AspNetCore.Mvc;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
