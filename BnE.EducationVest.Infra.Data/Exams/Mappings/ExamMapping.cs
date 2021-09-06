using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("exam");


            builder
                .Property(x => x.ExamNumber)
                .IsRequired();

            builder
                .HasMany(x => x.Questions)
                .WithOne(x => x.Exam)
                .HasForeignKey(x => x.ExamId);

            builder.Property(x => x.ExamModel)
                .HasConversion(toDB => (int)toDB,
                                fromDB => (EExamModel)fromDB)
                .IsRequired();

            builder.Property(x => x.ExamType)
                .HasConversion(toDB => (int)toDB,
                                fromDB => (EExamType)fromDB);

            builder.Property(x => x.ExamTopic)
              .HasConversion(toDB => (int)toDB,
                              fromDB => (EExamTopic)fromDB);

            builder.HasOne(x => x.FatherExamModule)
                .WithMany(a => a.ChildExamModule)
                .HasForeignKey(x => x.FatherExamModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Periods)
                .WithOne(x => x.Exam)
                .HasForeignKey(x => x.ExamId);
        }
    }
}
