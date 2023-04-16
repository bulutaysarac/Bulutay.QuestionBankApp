using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bulutay.QuestionBankApp.Persistance.Context;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Persistance.Repositories;

namespace Bulutay.QuestionBankApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuestionBankContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Express"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILectureRepository, LectureRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }
    }
}
