using BnE.EducationVest.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Exams.Mappings
{
    public class UserOptinMapping : IEntityTypeConfiguration<UserOptin>
    {
        public void Configure(EntityTypeBuilder<UserOptin> builder)
        {
            builder.HasKey(x => new { x.UserId, x.OptinId });

            builder
                .HasOne(x => x.Optin)
                .WithMany(x => x.UsersAccepted)
                .HasForeignKey(x => x.OptinId);

            builder
               .HasOne(x => x.User)
               .WithMany(x => x.Optins)
               .HasForeignKey(x => x.UserId);
        }
    }
}
