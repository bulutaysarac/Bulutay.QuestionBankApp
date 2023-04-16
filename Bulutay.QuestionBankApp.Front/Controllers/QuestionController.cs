using Bulutay.QuestionBankApp.Front.Extensions;
using Bulutay.QuestionBankApp.Front.HttpRequestHelpers;
using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<QuestionCreateModel> _questionCreateValidator;
        private readonly IValidator<QuestionUpdateModel> _questionUpdateValidator;
        private string userToken = "";

        public QuestionController(IHttpClientFactory httpClientFactory, IValidator<QuestionCreateModel> questionCreateValidator, IValidator<QuestionUpdateModel> questionUpdateValidator)
        {
            _httpClientFactory = httpClientFactory;
            _questionCreateValidator = questionCreateValidator;
            _questionUpdateValidator = questionUpdateValidator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            userToken = User.Claims.FirstOrDefault(x => x.Type == "AccessToken").Value;
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var questions = await QBRequests.GetAllAsync<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, userToken);
            return questions == null ? View() : View(questions);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            var users = await QBRequests.GetAllAsync<UserListModel>(_httpClientFactory, QBApiLinks.USERS, userToken);
            var categories = await QBRequests.GetAllAsync<CategoryListModel>(_httpClientFactory, QBApiLinks.CATEGORIES, userToken);

            ViewBag.Departments = departments;
            ViewBag.Users = users;
            ViewBag.Categories = categories;
            ViewBag.DataLectureId = 0;

            return View(new QuestionCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionCreateModel model)
        {
            var validationResult = _questionCreateValidator.Validate(model);
            if (validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.CreateAsync(_httpClientFactory, content, QBApiLinks.QUESTIONS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Question") : View(model);
            }

            this.AddValidationErrorsToModelState(validationResult);

            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            var users = await QBRequests.GetAllAsync<UserListModel>(_httpClientFactory, QBApiLinks.USERS, userToken);
            var categories = await QBRequests.GetAllAsync<CategoryListModel>(_httpClientFactory, QBApiLinks.CATEGORIES, userToken);

            ViewBag.Departments = departments;
            ViewBag.Users = users;
            ViewBag.Categories = categories;
            ViewBag.DataLectureId = model.LectureId;

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            var users = await QBRequests.GetAllAsync<UserListModel>(_httpClientFactory, QBApiLinks.USERS, userToken);
            var categories = await QBRequests.GetAllAsync<CategoryListModel>(_httpClientFactory, QBApiLinks.CATEGORIES, userToken);
            var question = await QBRequests.Get<QuestionListModel>(_httpClientFactory, QBApiLinks.QUESTIONS, id, userToken);

            ViewBag.Departments = departments;
            ViewBag.Users = users;
            ViewBag.Categories = categories;
            ViewBag.DataLectureId = question.Lecture.Id;

            return View(new QuestionUpdateModel()
            {
                Id = question.Id,
                Body = question.Body,
                CategoryId = question.Category.Id,
                IsCorrect = question.IsCorrect,
                DepartmentId = question.Lecture.Department.Id,
                LectureId = question.Lecture.Id,
                UserId = question.User.Id,
                Options = question.Options
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(QuestionUpdateModel model)
        {
            var validationResult = _questionUpdateValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.UpdateAsync(_httpClientFactory, content, QBApiLinks.QUESTIONS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Question") : View(model);
            }

            this.AddValidationErrorsToModelState(validationResult);

            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            var users = await QBRequests.GetAllAsync<UserListModel>(_httpClientFactory, QBApiLinks.USERS, userToken);
            var categories = await QBRequests.GetAllAsync<CategoryListModel>(_httpClientFactory, QBApiLinks.CATEGORIES, userToken);
            
            ViewBag.Departments = departments;
            ViewBag.Users = users;
            ViewBag.Categories = categories;
            ViewBag.DataLectureId = model.LectureId;

            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await QBRequests.RemoveAsync(_httpClientFactory, QBApiLinks.QUESTIONS, id, userToken);
            return response.IsSuccessStatusCode ? RedirectToAction("List", "Question") : RedirectToAction("Index", "Admin");
        }
    }
}
