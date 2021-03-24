using BnE.EducationVest.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Common
{
    public class EducationVestContext : DbContext
    {
        DbSet<User> Users { get; set; }
        public EducationVestContext(DbContextOptions<EducationVestContext> options) :
            base(options)
        {
        }
    }
}
