using Bulutay.QuestionBankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.QuestionBankApp.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new Category[]
            {
                new Category()
                {
                    Id = 1,
                    Definition = "Klasik"
                },
                new Category()
                {
                    Id = 2,
                    Definition = "Çoktan Seçmeli"
                },
                new Category()
                {
                    Id = 3,
                    Definition = "Doğru Yanlış"
                }
            });
        }
    }
}
