using BnE.EducationVest.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BnE.EducationVest.Infra.Data.Users.Mappings
{
    public class ExternalUserProfileMapping : IEntityTypeConfiguration<ExternalUserProfile>
    {
        public void Configure(EntityTypeBuilder<ExternalUserProfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("external_user_profile");

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.ExternalUserProfile)
                .HasForeignKey<ExternalUserProfile>(x => x.UserId)
                .IsRequired();

            builder
             .Property(x => x.ExpectedCollege)
             .HasColumnType("varchar(30)");

            builder
             .Property(x => x.ExpectedCourse)
             .HasColumnType("varchar(100)");

            builder
             .Property(x => x.ActualOccupation)
             .HasColumnType("varchar(100)");

            builder
             .Property(x => x.ActualCollege)
             .HasColumnType("text");
        }
    }
}
