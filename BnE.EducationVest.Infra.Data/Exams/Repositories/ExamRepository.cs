using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Infra.Data.Common;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnE.EducationVest.Domain.Users.Entities;

namespace BnE.EducationVest.Infra.Data.Exams.Repositories
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(EducationVestContext context) : base(context)
        {
        }

        public async Task<List<Exam>> GetAvailableExams()
        {
            var actualDate = DateTime.Now;
            //TODO: VERIFICAR SE USUARIO COMPLETOU EXAME
            return await _db
                .Include(x => x.Periods)
                .Where(exam => exam.Periods.Any(x => x.OpenDate <= actualDate && x.CloseDate > actualDate.AddMinutes(10)))
                .ToListAsync();
        }

        public async Task<Exam> GetByIdWithAllIncludes(Guid id)
        {
           return await _db
                .Include(x => x.Periods)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Alternatives)
                .ThenInclude(x => x.TextContent)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Enunciated)
                .AsNoTracking()
                .FirstAsync(x => x.Id == id);
        }

        public async Task AddExamPeriodsAsync(Exam exam)
        {
            _context.Entry(exam).State = EntityState.Modified;
            foreach (var period in exam.Periods)
            {
                var teste = _context.Entry(period).State;
                if(teste == EntityState.Modified)
                    _context.Entry(period).State = EntityState.Added;
            }
            await _context.Commit();
        }
    }
}
