using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class GeneralMetricMapping : IEntityTypeConfiguration<GeneralMetric>
    {
        public void Configure(EntityTypeBuilder<GeneralMetric> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("general_metrics");

            builder
                .Property(x => x.MetricValue)
                .HasColumnType("json")
                .HasConversion
                (
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<ExamGeneralMetrics>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );

            builder
                .HasOne(x => x.Exam)
                .WithMany(x => x.GeneralMetrics)
                .HasForeignKey(x => x.ExamId)
                .IsRequired();
        }
    }
}
