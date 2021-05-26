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

        public async Task AddExamQuestionAnswer(QuestionAnswer questionAnswer)
        {
            await _context
                .QuestionsAnswers
                .AddAsync(questionAnswer);

            await _context.Commit();
        }
        public async Task UpdateExamQuestionAnswer(QuestionAnswer questionAnswer)
        {
            _context
                .QuestionsAnswers
                .Update(questionAnswer);
            await _context.Commit();
        }
        public async Task<QuestionAnswer> GetQuestionAnswerById(Guid questionAnswerId)
        {
            return await _context
                        .QuestionsAnswers
                        .FirstOrDefaultAsync(x => x.Id == questionAnswerId);
        }
        public async Task<List<Question>> GetExamQuestions(Guid examId, Guid userId, int from, int to)
        {
            return await _context
                .Questions
                .OrderBy(x => x.Index)
                .Skip(from)
                .Take(to)
                .Where(x => x.ExamId == examId)
                .Include(x => x.QuestionAnswers.Where(qa => qa.UserId == userId))
                .ThenInclude(x => x.ChosenAlternative)
                .Include(x => x.Enunciated)
                .Include(x => x.Alternatives)
                .ThenInclude(x => x.TextContent)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Question>> GetQuestionWithAnswersByUserExamAsync(Guid examId, Guid userId)
        {
            return await _context
                            .Questions
                            .Where(x => x.ExamId == examId)
                            .Include(x => x.QuestionAnswers.Where(x => x.UserId == userId))
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<Exam> GetExamWithPeriodsById(Guid examId)
        {
            return await _db
                         .Include(x => x.Periods)
                         .FirstAsync(x => x.Id == examId);
        }
    }
}
