using Bulutay.QuestionBankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.QuestionBankApp.Persistance.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new Department[]
            {
                new Department()
                {
                    Id = 1,
                    Definition = "Bilgisayar Mühendisliği"
                },
                new Department()
                {
                    Id = 2,
                    Definition = "Yazılım Mühendisliği"
                },
                new Department()
                {
                    Id = 3,
                    Definition = "Elektrik Elektronik Mühendisliği"
                },
                new Department()
                {
                    Id = 4,
                    Definition = "Endüstri Mühendisliği"
                },
                new Department()
                {
                    Id = 5,
                    Definition = "İnşaat Mühendisliği"
                }
            });
        }
    }
}
