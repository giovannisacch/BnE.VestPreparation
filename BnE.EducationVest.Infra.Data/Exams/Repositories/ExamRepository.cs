using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Infra.Data.Common;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BnE.EducationVest.Domain.Users.Entities;
using BnE.EducationVest.Domain.Exam.RelationEntities;

namespace BnE.EducationVest.Infra.Data.Exams.Repositories
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(EducationVestContext context) : base(context)
        {
        }

        public async Task<List<Exam>> GetAvailableExamsByUser(Guid userId)
        {
            var actualDate = DateTime.Now;
            var exams = await _db
                .Include(x => x.Periods)
                .Include(x => x.Finalizeds.Where(x => x.UserId == userId))
                .Where(exam => exam.Periods.Any(x => x.OpenDate <= actualDate && x.CloseDate > actualDate.AddMinutes(10)))
                .ToListAsync();
            return exams;
        }
        public async Task DeleteAllUserAnswersInExam(Guid userId, Guid examId)
        {
            var answers = _context.QuestionsAnswers.Where(x => x.UserId == userId && x.Question.ExamId == examId).ToList();
            _context.RemoveRange(answers);
            await _context.Commit();
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
        public async Task<QuestionAnswer> GetQuestionAnswerByIdAndUser(Guid questionAnswerId, Guid userId)
        {
            return await _context
                        .QuestionsAnswers
                        .Include(x => x.Question)
                        .ThenInclude(x => x.Exam)
                        .ThenInclude(x => x.Finalizeds.Where(x => x.UserId == userId))
                        .FirstOrDefaultAsync(x => x.Id == questionAnswerId);
        }
        public async Task<List<Question>> GetExamQuestions(Guid examId, Guid userId, int from, int to)
        {
            return await _context
                .Questions
                .Where(x => x.ExamId == examId)
                .OrderBy(x => x.Index)
                .Skip(from)
                .Take(to)
                .Include(x => x.QuestionAnswers.Where(qa => qa.UserId == userId))
                .ThenInclude(x => x.ChosenAlternative)
                .Include(x => x.Enunciated)
                .Include(x => x.Alternatives.OrderBy(x => x.Index))
                .ThenInclude(x => x.TextContent)
                .Include(x => x.SupportingText)
                .ThenInclude(x => x.Content)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Exam> GetExamWithQuestionsAndUserAnswers(Guid examId, Guid userId)
        {
            return await _db
                            .Where(x => x.Id == examId)
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.QuestionAnswers.Where(x => x.UserId == userId))
                            .ThenInclude(x => x.ChosenAlternative)
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.Subject)
                            .ThenInclude(x => x.SubjectFather)
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.Alternatives)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
        }

        public async Task<Exam> GetExamWithPeriodsById(Guid examId)
        {
            return await _db
                         .Include(x => x.Periods)
                         .FirstAsync(x => x.Id == examId);
        }

        public async Task FinalizeExam(FinalizedExam finalizedExam)
        {
            await _context
                    .FinalizedExams
                    .AddAsync(finalizedExam);
            await _context.Commit();
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await 
                _context
                .Subjects
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Exam>> GetUserFinalizedExams(Guid userId)
        {
            return await
                    _db
                    .Include(x => x.Finalizeds)
                    .Where(x => x.Finalizeds.Any(x => x.UserId == userId))
                    .ToListAsync();
        }
        public async Task<List<Exam>> GetUserFinalizedExamsWithAnswers(Guid userId)
        {
            return await
                    _db
                    .Include(x => x.Finalizeds)
                    .Where(x => x.Finalizeds.Any(x => x.UserId == userId))
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.QuestionAnswers)
                    .ThenInclude(x => x.ChosenAlternative)
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Subject)
                    .ThenInclude(x => x.SubjectFather)
                    .ToListAsync();
        }
        public async Task<Question> GetLastExamQuestionAnsweredByUserAsync(Guid examId, Guid userId)
        {
            return await
                    _context.Questions
                    .Include(x => x.QuestionAnswers)
                    .Where(x => x.ExamId == examId && x.QuestionAnswers.FirstOrDefault(x => x.UserId == userId) != null)
                    .OrderByDescending(x => x.Index)
                    .FirstAsync();
        }
        //public async Task<List<Exam>> GetExamsFinalizedByUser(Guid userId)
        //{
        //    var answers = await _context
        //        .QuestionsAnswers
        //        .Where(x => x.UserId == userId)
        //        .Include(x => x.Question)
        //        .ThenInclude(x => x.Exam)
        //        .ToListAsync();
        //    //TODO: Criar tabela entre usuario e exame para marcar os exames finalizados ou atualizar o count de forma dinamica
        //    var answersFromFinalizedExams = answers.Select(x => x.Question).GroupBy(x => x.ExamId);
        //    return answersFromFinalizedExams;

        //}
    }
}
