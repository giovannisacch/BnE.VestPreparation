using BnE.EducationVest.Domain.Common.Infra;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using BnE.EducationVest.Domain.Users.Entities;
using BnE.EducationVest.Infra.Data.Exams.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Common
{
    public class EducationVestContext : DbContext, IUnitOfWork
    {
        DbSet<User> Users { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Alternative> Alternatives { get; set; }
        DbSet<IncrementedTextVO> IncrementedTexts { get; set; }
        DbSet<ExamPeriodVO> ExamPeriods { get; set; }

        public EducationVestContext(DbContextOptions<EducationVestContext> options) :
            base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExamMapping());
            modelBuilder.ApplyConfiguration(new QuestionMapping());
            modelBuilder.ApplyConfiguration(new AlternativeMapping());
            modelBuilder.ApplyConfiguration(new IncrementedTextVOMapping());
            modelBuilder.ApplyConfiguration(new ExamPeriodVOMapping());
        }

        public async Task<bool> Commit()
        {
            //Garantindo que atualizo/crio uma data de cadastro sempre que commito um objeto que tenha essa propriedade
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                    entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
