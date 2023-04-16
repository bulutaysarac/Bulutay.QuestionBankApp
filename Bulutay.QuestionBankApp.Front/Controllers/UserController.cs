using Bulutay.QuestionBankApp.Front.HttpRequestHelpers;
using Bulutay.QuestionBankApp.Front.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text;
using System.Linq;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<UserCreateModel> _userCreateValidator;
        private readonly IValidator<UserUpdateModel> _userUpdateValidator;
        private string userToken = "";

        public UserController(IHttpClientFactory httpClientFactory, IValidator<UserCreateModel> userCreateValidator, IValidator<UserUpdateModel> userUpdateValidator)
        {
            _httpClientFactory = httpClientFactory;
            _userCreateValidator = userCreateValidator;
            _userUpdateValidator = userUpdateValidator;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            userToken = User.Claims.FirstOrDefault(x => x.Type == "AccessToken").Value;
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> List()
        {
            var users = await QBRequests.GetAllAsync<UserListModel>(_httpClientFactory, QBApiLinks.USERS, userToken);
            return users == null ? View() : View(users);
        }

        public async Task<IActionResult> Create()
        {
            var rolesResponse = await QBRequests.GetAllAsync<RoleListModel>(_httpClientFactory, QBApiLinks.ROLES, userToken);
            return View(new UserCreateModel()
            {
                DbRoles = rolesResponse
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            var validationResult = _userCreateValidator.Validate(model);
            if (validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.CreateAsync(_httpClientFactory, content, QBApiLinks.USERS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "User") : View(model);
            }
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var rolesResponse = await QBRequests.GetAllAsync<RoleListModel>(_httpClientFactory, QBApiLinks.ROLES, userToken);
            model.DbRoles = rolesResponse;
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var user = await QBRequests.Get<UserListModel>(_httpClientFactory, QBApiLinks.USERS, id, userToken);
            var roles = await QBRequests.GetAllAsync<RoleListModel>(_httpClientFactory, QBApiLinks.ROLES, userToken);
            return user == null ? View() : View(new UserUpdateModel()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                DbRoles = roles,
                OldRoleIds = user.Roles.Select(x => x.Id).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateModel model)
        {
            if (model.DbRoles?.Any(x => x.IsSelected) == true)
            {
                var checkedRoleIds = model.DbRoles.Where(x => x.IsSelected).Select(x => x.Id).ToList();

                if (model.OldRoleIds?.Any() == true)
                {
                    model.AddedRoleIds = checkedRoleIds.Except(model.OldRoleIds).ToList();
                    model.RemovedRoleIds = model.OldRoleIds.Except(checkedRoleIds).ToList();
                }
                else
                {
                    model.AddedRoleIds = checkedRoleIds;
                    model.RemovedRoleIds = null;
                }
            }
            else
            {
                model.AddedRoleIds = null;
                model.RemovedRoleIds = model.OldRoleIds;
            }
            var validationResult = _userUpdateValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await QBRequests.UpdateAsync(_httpClientFactory, content, QBApiLinks.USERS, userToken);
                return response.IsSuccessStatusCode ? RedirectToAction("List", "User") : View(model);
            }
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var rolesResponse = await QBRequests.GetAllAsync<RoleListModel>(_httpClientFactory, QBApiLinks.ROLES, userToken);
            model.DbRoles = rolesResponse;
            return View(model);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await QBRequests.RemoveAsync(_httpClientFactory, QBApiLinks.USERS, id, userToken);
            return response.IsSuccessStatusCode ? RedirectToAction("List", "User") : RedirectToAction("Index", "Admin");
        }
    }
}
