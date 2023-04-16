using Bulutay.QuestionBankApp.Domain.Entities;
using Bulutay.QuestionBankApp.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bulutay.QuestionBankApp.Persistance.Context
{
    public class QuestionBankContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Lecture> Lectures => Set<Lecture>();
        public DbSet<Option> Options => Set<Option>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public QuestionBankContext(DbContextOptions opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
