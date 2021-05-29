using BnE.EducationVest.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BnE.EducationVest.Infra.Data.Users.Mappings
{
    public class UserMenuMapping : IEntityTypeConfiguration<UserMenu>
    {
        public void Configure(EntityTypeBuilder<UserMenu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("user_menu");

            builder
                .Property(x => x.Key)
                .HasColumnType("varchar(30)");

            builder
                .Property(x => x.Label)
                .HasColumnType("varchar(50)");

        }
    }
}
