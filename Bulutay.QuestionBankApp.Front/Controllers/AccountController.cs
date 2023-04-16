using Bulutay.QuestionBankApp.Front.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using FluentValidation;
using Bulutay.QuestionBankApp.Front.Extensions;

namespace Bulutay.QuestionBankApp.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<UserSignInModel> _userSignInValidator;
        private readonly IValidator<UserSignUpModel> _userSignUpValidator;

        public AccountController(IHttpClientFactory httpClientFactory, IValidator<UserSignInModel> userSignInValidator, IValidator<UserSignUpModel> userSignUpValidator)
        {
            _httpClientFactory = httpClientFactory;
            _userSignInValidator = userSignInValidator;
            _userSignUpValidator = userSignUpValidator;
        }

        public IActionResult SignIn()
        {
            return View(new UserSignInModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            var validationResult = _userSignInValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5817/api/auth/signin", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(tokenModel.Token);
                        var claims = token.Claims.ToList();
                        if (tokenModel.Token != null)
                        {
                            claims.Add(new Claim("AccessToken", tokenModel.Token));
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties()
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                }
            }
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn", "Account");
        }

        public IActionResult SignUp()
        {
            return View(new UserSignUpModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpModel model)
        {
            var validationResult = _userSignUpValidator.Validate(model);
            if(validationResult.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5817/api/auth/signup", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(tokenModel.Token);
                        var claims = token.Claims.ToList();
                        if (tokenModel.Token != null)
                        {
                            claims.Add(new Claim("AccessToken", tokenModel.Token));
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties()
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı kullanılmaktadır!");
                }
            }
            this.AddValidationErrorsToModelState(validationResult);
            return View(model);
        }
    }
}
