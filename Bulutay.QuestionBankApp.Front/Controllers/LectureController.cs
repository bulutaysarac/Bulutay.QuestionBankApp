using Bulutay.QuestionBankApp.Front.Extensions;
using Bulutay.QuestionBankApp.Front.HttpRequestHelpers;
using Bulutay.QuestionBankApp.Front.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    public class LectureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<LectureUpdateModel> _lectureUpdateValidator;
        private readonly IValidator<LectureCreateModel> _lectureCreateValidator;
        private string userToken = "";

        public LectureController(IHttpClientFactory httpClientFactory, IValidator<LectureUpdateModel> lectureUpdateValidator, IValidator<LectureCreateModel> lectureCreateValidator)
        {
            _httpClientFactory = httpClientFactory;
            _lectureUpdateValidator = lectureUpdateValidator;
            _lectureCreateValidator = lectureCreateValidator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            userToken = User.Claims.FirstOrDefault(x => x.Type == "AccessToken").Value;
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var lectures = await QBRequests.GetAllAsync<LectureListModel>(_httpClientFactory, QBApiLinks.LECTURES, userToken);
            return lectures == null ? View() : View(lectures);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            ViewBag.Departments = departments;
            return View(new LectureCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LectureCreateModel model)
        {
            var validationResult = _lectureCreateValidator.Validate(model);
            if (validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.CreateAsync(_httpClientFactory, content, QBApiLinks.LECTURES, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Lecture") : View(model);
            }

            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            ViewBag.Departments = departments;

            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            var lecture = await QBRequests.Get<LectureListModel>(_httpClientFactory, QBApiLinks.LECTURES, id, userToken);
            ViewBag.Departments = departments;
            return View(new LectureUpdateModel()
            {
                Id = lecture.Id,
                Name = lecture.Name,
                DepartmentId = lecture.Department.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(LectureUpdateModel model)
        {
            var validationResult = _lectureUpdateValidator.Validate(model);
            if (validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.UpdateAsync(_httpClientFactory, content, QBApiLinks.LECTURES, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Lecture") : View(model);
            }

            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            ViewBag.Departments = departments;

            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await QBRequests.RemoveAsync(_httpClientFactory, QBApiLinks.LECTURES, id, userToken);
            return response.IsSuccessStatusCode ? RedirectToAction("List", "Lecture") : RedirectToAction("Index", "Admin");
        }
    }
}
