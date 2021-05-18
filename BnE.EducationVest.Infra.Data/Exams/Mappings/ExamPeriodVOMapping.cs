using BnE.EducationVest.Domain.Exam.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class ExamPeriodVOMapping : IEntityTypeConfiguration<ExamPeriodVO>
    {
        public void Configure(EntityTypeBuilder<ExamPeriodVO> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ExamPeriod");


            builder
                .Property(x => x.OpenDate)
                .IsRequired();

            builder
                .Property(x => x.CloseDate)
                .IsRequired();

            builder
                .HasOne(x => x.Exam)
                .WithMany(x => x.Periods)
                .HasForeignKey(x => x.ExamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
