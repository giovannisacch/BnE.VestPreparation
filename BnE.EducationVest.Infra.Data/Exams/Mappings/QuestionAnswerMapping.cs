using BnE.EducationVest.Domain.Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class QuestionAnswerMapping : IEntityTypeConfiguration<QuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("question_answers");

            builder
                .HasOne(x => x.Question)
                .WithMany(x => x.QuestionAnswers)
                .HasForeignKey(x => x.QuestionId);

            builder
               .HasOne(x => x.ChosenAlternative)
               .WithMany(x => x.QuestionAnswers)
               .HasForeignKey(x => x.ChosenAlternativeId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.QuestionAnswers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
