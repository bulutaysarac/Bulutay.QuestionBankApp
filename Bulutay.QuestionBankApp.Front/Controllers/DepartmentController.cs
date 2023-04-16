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
    public class DepartmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<DepartmentCreateModel> _departmentCreateValidator;
        private readonly IValidator<DepartmentUpdateModel> _departmentUpdateValidator;
        private string userToken = "";

        public DepartmentController(IHttpClientFactory httpClientFactory, IValidator<DepartmentCreateModel> departmentCreateValidator, IValidator<DepartmentUpdateModel> departmentUpdateValidator)
        {
            _httpClientFactory = httpClientFactory;
            _departmentCreateValidator = departmentCreateValidator;
            _departmentUpdateValidator = departmentUpdateValidator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            userToken = User.Claims.FirstOrDefault(x => x.Type == "AccessToken").Value;
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var departments = await QBRequests.GetAllAsync<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, userToken);
            return departments == null ? View() : View(departments);
        }

        public IActionResult Create()
        {
            return View(new DepartmentCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateModel model)
        {
            var validationResult = _departmentCreateValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.CreateAsync(_httpClientFactory, content, QBApiLinks.DEPARTMENTS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Department") : View(model);
            }
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var department = await QBRequests.Get<DepartmentListModel>(_httpClientFactory, QBApiLinks.DEPARTMENTS, id, userToken);
            return department == null ? View() : View(new DepartmentUpdateModel()
            {
                Id = department.Id,
                Definition = department.Definition
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(DepartmentUpdateModel model)
        {
            var validationResult = _departmentUpdateValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.UpdateAsync(_httpClientFactory, content, QBApiLinks.DEPARTMENTS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "Department") : View(model);
            }
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await QBRequests.RemoveAsync(_httpClientFactory, QBApiLinks.DEPARTMENTS, id, userToken);
            return response.IsSuccessStatusCode ? RedirectToAction("List", "Department") : RedirectToAction("Index", "Admin");
        }
    }
}
