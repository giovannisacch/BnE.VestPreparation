using BnE.EducationVest.Domain.Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class AlternativeMapping : IEntityTypeConfiguration<Alternative>
    {
        public void Configure(EntityTypeBuilder<Alternative> builder)
        {
            builder.HasKey(x => new { x.QuestionId, x.Index });
            builder.ToTable("Alternative");

            builder
                .HasOne(x => x.TextContent)
                .WithOne(x => x.Alternative)
                .HasForeignKey<Alternative>(x => x.TextContentId)
                .IsRequired();

            builder
              .HasOne(x => x.Question)
              .WithMany(x => x.Alternatives)
              .HasForeignKey(x => x.QuestionId)
              .IsRequired();

            builder
                .Property(x => x.Index)
                .IsRequired();

            builder
                .Property(x => x.IsCorrect)
                .IsRequired();
        }
    }
}
