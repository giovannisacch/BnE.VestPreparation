using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using BnE.EducationVest.Domain.Exam.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class IncrementedTextVOMapping : IEntityTypeConfiguration<IncrementedTextVO>
    {
        public void Configure(EntityTypeBuilder<IncrementedTextVO> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("IncrementedText");

            builder
                .Property(x => x.Content)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder
                .Property(x => x.Increments)
                .HasColumnType("jdoc")
                .HasConversion
                (
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<CompleteTextIncrementVO>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            builder
                .HasOne(x => x.Question)
                .WithOne(x => x.Enunciated)
                .HasForeignKey<Question>(x => x.EnunciatedId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Alternative)
                .WithOne(x => x.TextContent)
                .HasForeignKey<Alternative>(x => x.TextContentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
