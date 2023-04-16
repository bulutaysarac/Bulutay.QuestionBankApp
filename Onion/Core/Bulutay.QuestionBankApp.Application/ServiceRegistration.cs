using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Application.Mappings;
using Bulutay.QuestionBankApp.Application.Services;
using Bulutay.QuestionBankApp.Application.ValidationRules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bulutay.QuestionBankApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>()
                {
                    new CategoryProfile(),
                    new DepartmentProfile(),
                    new UserProfile(),
                    new RoleProfile(),
                    new LectureProfile(),
                    new QuestionProfile(),
                    new OptionProfile()
                });
            });

            services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();

            services.AddTransient<IValidator<DepartmentCreateDto>, DepartmentCreateDtoValidator>();
            services.AddTransient<IValidator<DepartmentUpdateDto>, DepartmentUpdateDtoValidator>();

            services.AddTransient<IValidator<RoleCreateDto>, RoleCreateDtoValidator>();
            services.AddTransient<IValidator<RoleUpdateDto>, RoleUpdateDtoValidator>();

            services.AddTransient<IValidator<UserCreateDto>, UserCreateDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();
            services.AddTransient<IValidator<UserCheckDto>, UserSignInDtoValidator>();

            services.AddTransient<IValidator<LectureUpdateDto>, LectureUpdateDtoValidator>();
            services.AddTransient<IValidator<LectureCreateDto>, LectureCreateDtoValidator>();

            services.AddTransient<IValidator<QuestionUpdateDto>, QuestionUpdateDtoValidator>();
            services.AddTransient<IValidator<QuestionCreateDto>, QuestionCreateDtoValidator>();

            services.AddTransient<IValidator<OptionCreateDto>, OptionCreateDtoValidator>();
            services.AddTransient<IValidator<OptionUpdateDto>, OptionUpdateDtoValidator>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILectureService, LectureService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IOptionService, OptionService>();
        }
    }
}
