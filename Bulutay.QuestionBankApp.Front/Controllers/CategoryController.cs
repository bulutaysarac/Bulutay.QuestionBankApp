using Bulutay.QuestionBankApp.Front.Extensions;
using Bulutay.QuestionBankApp.Front.HttpRequestHelpers;
using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<CategoryCreateModel> _categoryCreateValidator;
        private readonly IValidator<CategoryUpdateModel> _categoryUpdateValidator;
        private string userToken = "";

        public CategoryController(IHttpClientFactory httpClientFactory, IValidator<CategoryCreateModel> categoryCreateValidator, IValidator<CategoryUpdateModel> categoryUpdateValidator)
        {
            _httpClientFactory = httpClientFactory;
            _categoryCreateValidator = categoryCreateValidator;
            _categoryUpdateValidator = categoryUpdateValidator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            userToken = User.Claims.FirstOrDefault(x => x.Type == "AccessToken").Value;
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var categories = await QBRequests.GetAllAsync<CategoryListModel>(_httpClientFactory, QBApiLinks.CATEGORIES, userToken);
            return categories == null ? View() : View(categories);
        }

        public IActionResult Create()
        {
            return View(new CategoryCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateModel model)
        {
            var validationResult = _categoryCreateValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.CreateAsync(_httpClientFactory, content, QBApiLinks.CATEGORIES, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Category") : View(model);
            }
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await QBRequests.Get<CategoryListModel>(_httpClientFactory, QBApiLinks.CATEGORIES, id, userToken);
            return category == null ? View() : View(new CategoryUpdateModel() 
            {
                Id = category.Id, Definition = category.Definition 
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateModel model)
        {
            var validationResult = _categoryUpdateValidator.Validate(model);
            if(validationResult.IsValid )
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.UpdateAsync(_httpClientFactory, content, QBApiLinks.CATEGORIES, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Category") : View(model);
            }
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await QBRequests.RemoveAsync(_httpClientFactory, QBApiLinks.CATEGORIES, id, userToken);
            return response.IsSuccessStatusCode ? RedirectToAction("List", "Category") : RedirectToAction("Index", "Admin");
        }
    }
}
