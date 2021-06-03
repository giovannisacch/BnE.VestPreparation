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
    public class OptinMapping : IEntityTypeConfiguration<Optin>
    {
        public void Configure(EntityTypeBuilder<Optin> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.UsersAccepted)
                .WithOne(x => x.Optin)
                .HasForeignKey(x => x.OptinId);
        }
    }
}
