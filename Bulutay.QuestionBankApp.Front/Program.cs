using AutoMapper;
using Bulutay.QuestionBankApp.Front.Mappings;
using Bulutay.QuestionBankApp.Front.Models;
using Bulutay.QuestionBankApp.Front.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bulutay.QuestionBankApp.Front
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>()
                {
                    new LectureModelProfile()
                });
            });

            builder.Services.AddHttpClient();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Account/SignIn";
                opt.LogoutPath = "/Account/SignOut";
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "QuestionBankAppCookie";
            });

            builder.Services.AddScoped<IValidator<CategoryCreateModel>, CategoryCreateModelValidator>();
            builder.Services.AddScoped<IValidator<CategoryUpdateModel>, CategoryUpdateModelValidator>();

            builder.Services.AddScoped<IValidator<DepartmentCreateModel>, DepartmentCreateModelValidator>();
            builder.Services.AddScoped<IValidator<DepartmentUpdateModel>, DepartmentUpdateModelValidator>();

            builder.Services.AddScoped<IValidator<LectureCreateModel>, LectureCreateModelValidator>();
            builder.Services.AddScoped<IValidator<LectureUpdateModel>, LectureUpdateModelValidator>();

            builder.Services.AddScoped<IValidator<QuestionCreateModel>, QuestionCreateModelValidator>();
            builder.Services.AddScoped<IValidator<QuestionUpdateModel>, QuestionUpdateModelValidator>();

            builder.Services.AddScoped<IValidator<OptionCreateModel>, OptionCreateModelValidator>();
            builder.Services.AddScoped<IValidator<OptionUpdateModel>, OptionUpdateModelValidator>();

            builder.Services.AddScoped<IValidator<UserCreateModel>, UserCreateModelValidator>();
            builder.Services.AddScoped<IValidator<UserUpdateModel>, UserUpdateModelValidator>();
            builder.Services.AddScoped<IValidator<UserSignInModel>, UserSignInModelValidator>();
            builder.Services.AddScoped<IValidator<UserSignUpModel>, UserSignUpModelValidator>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}