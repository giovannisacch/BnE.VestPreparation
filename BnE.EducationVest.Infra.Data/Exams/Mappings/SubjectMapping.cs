using BnE.EducationVest.Domain.Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class SubjectMapping : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Subject");
            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(250)");
            builder
                .HasOne(x => x.SubjectFather)
                .WithMany(x => x.SubjectChild)
                .HasForeignKey(x => x.SubjectFatherId);

            builder
                .HasMany(x => x.Questions)
                .WithOne(x => x.Subject)
                .HasForeignKey(x => x.SubjectId);

        }
    }
}
