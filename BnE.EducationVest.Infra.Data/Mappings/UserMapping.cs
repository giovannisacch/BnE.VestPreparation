using BnE.EducationVest.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(owns => owns.Address, address =>
            {
                address.Property(x => x.CEP)
                        .HasColumnName("Address.CEP")
                        .HasColumnType("char(9)");

                address.Property(x => x.Street)
                       .HasColumnName("Address.Street")
                       .HasColumnType("varchar(150)");

                address.Property(x => x.Neighborhood)
                       .HasColumnName("Address.Neighborhood")
                       .HasColumnType("varchar(50)");
                 
                address.Property(x => x.City)
                       .HasColumnName("Adress.City")
                       .HasColumnType("char(50)");

                address.Property(x => x.State)
                     .HasColumnName("Adress.State")
                     .HasColumnType("char(2)");
            });

            builder.Ignore(x => x.CPF);
        }
    }
}
