using BnE.EducationVest.Domain.Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Question");


            builder
                .Property(x => x.Index)
                .IsRequired();

            builder
                .HasOne(x => x.Enunciated)
                .WithOne(x => x.Question)
                .HasForeignKey<Question>(x => x.EnunciatedId)
                .IsRequired();

            builder
                .HasMany(x => x.Alternatives)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId)
                .IsRequired();

            builder
                .HasOne(x => x.Exam)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.ExamId)
                .IsRequired();
        }
    }
}
