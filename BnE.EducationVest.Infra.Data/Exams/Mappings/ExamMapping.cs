using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Exam");


            builder
                .Property(x => x.ExamNumber)
                .IsRequired();

            builder
                .HasMany(x => x.Questions)
                .WithOne(x => x.Exam)
                .HasForeignKey(x => x.ExamId);

            builder.Property(x => x.ExamType)
                .HasConversion(toDB => (int)toDB,
                                fromDB => (EExamType)fromDB)
                .IsRequired();
            builder
                .HasMany(x => x.Periods)
                .WithOne(x => x.Exam)
                .HasForeignKey(x => x.ExamId);
        }
    }
}
