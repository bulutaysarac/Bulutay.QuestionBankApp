using Bulutay.QuestionBankApp.Front.HttpRequestHelpers;
using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text;
using Bulutay.QuestionBankApp.Front.Extensions;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    public class OptionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<OptionCreateModel> _optionCreateValidator;
        private readonly IValidator<OptionUpdateModel> _optionUpdateValidator;
        private string userToken = "";

        public OptionController(IHttpClientFactory httpClientFactory, IValidator<OptionCreateModel> optionCreateValidator, IValidator<OptionUpdateModel> optionUpdateValidator)
        {
            _httpClientFactory = httpClientFactory;
            _optionCreateValidator = optionCreateValidator;
            _optionUpdateValidator = optionUpdateValidator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            userToken = User.Claims.FirstOrDefault(x => x.Type == "AccessToken").Value;
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var options = await QBRequests.GetAllAsync<OptionListModel>(_httpClientFactory, QBApiLinks.OPTIONS, userToken);
            return options == null ? View() : View(options);
        }

        public async Task<IActionResult> Create()
        {
            var questions = await QBRequests.GetAllAsync<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, userToken);
            ViewBag.Questions = questions;
            return View(new OptionCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OptionCreateModel model)
        {
            var validationResult = _optionCreateValidator.Validate(model);
            if(validationResult.IsValid) 
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.CreateAsync(_httpClientFactory, content, QBApiLinks.OPTIONS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Option") : View(model);
            }
            var questions = await QBRequests.GetAllAsync<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, userToken);
            ViewBag.Questions = questions;
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var questions = await QBRequests.GetAllAsync<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, userToken);
            var option = await QBRequests.Get<OptionListModel>(_httpClientFactory, QBApiLinks.OPTIONS, id, userToken);
            ViewBag.Questions = questions;
            return View(new OptionUpdateModel()
            {
                Id = option.Id,
                Body = option.Body,
                IsCorrect = option.IsCorrect,
                QuestionId = option.QuestionId,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(OptionUpdateModel model)
        {
            var validationResult = _optionUpdateValidator.Validate(model);
            if (validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.UpdateAsync(_httpClientFactory, content, QBApiLinks.OPTIONS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Option") : View(model);
            }
            var questions = await QBRequests.GetAllAsync<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, userToken);
            ViewBag.Questions = questions;
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await QBRequests.RemoveAsync(_httpClientFactory, QBApiLinks.OPTIONS, id, userToken);
            return response.IsSuccessStatusCode ? RedirectToAction("List", "Option") : RedirectToAction("Index", "Admin");
        }
    }
}
