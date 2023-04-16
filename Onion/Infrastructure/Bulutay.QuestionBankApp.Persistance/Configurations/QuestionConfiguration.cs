using Bulutay.QuestionBankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.QuestionBankApp.Persistance.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasOne(x => x.Lecture)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.LectureId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.UserId);
        }
    }
}
