using Bulutay.QuestionBankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.QuestionBankApp.Persistance.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new Role[]
            {
                new Role()
                {
                    Id = 1,
                    Definition = "Admin"
                },
                new Role()
                {
                    Id = 2,
                    Definition = "Üye"
                },
            });
        }
    }
}
