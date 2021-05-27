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
    public class SupportingTextMapping : IEntityTypeConfiguration<SupportingText>
    {
        public void Configure(EntityTypeBuilder<SupportingText> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("supporting_text");

            builder
                .HasOne(x => x.Content)
                .WithOne(x => x.SupportingText)
                .HasForeignKey<SupportingText>(x => x.ContentId);

            builder
                .HasMany(x => x.Questions)
                .WithOne(x => x.SupportingText)
                .HasForeignKey(x => x.SupportingTextId);
        }
    }
}
