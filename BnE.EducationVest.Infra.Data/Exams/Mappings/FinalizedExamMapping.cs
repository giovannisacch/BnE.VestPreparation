using BnE.EducationVest.Domain.Exam.RelationEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class FinalizedExamMapping : IEntityTypeConfiguration<FinalizedExam>
    {
        public void Configure(EntityTypeBuilder<FinalizedExam> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ExamId });

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.FinalizedExams)
                .HasForeignKey(x => x.UserId);

            builder
               .HasOne(x => x.Exam)
               .WithMany(x => x.Finalizeds)
               .HasForeignKey(x => x.ExamId);
        }
    }
}
