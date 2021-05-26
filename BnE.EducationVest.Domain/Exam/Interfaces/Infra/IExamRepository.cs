using BnE.EducationVest.Domain.Common.Infra;
using BnE.EducationVest.Domain.Exam.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.Infra
{
    public interface IExamRepository : IBaseRepository<Entities.Exam>
    {
        Task<List<Entities.Exam>> GetAvailableExams();
        Task<Entities.Exam> GetByIdWithAllIncludes(Guid id);
        Task AddExamPeriodsAsync(Entities.Exam exam);
        Task AddExamQuestionAnswer(QuestionAnswer questionAnswer);
        Task UpdateExamQuestionAnswer(QuestionAnswer questionAnswer);
        Task<QuestionAnswer> GetQuestionAnswerById(Guid questionAnswerId);
        Task<List<Question>> GetExamQuestions(Guid examId, Guid userId, int from, int to);
        Task<List<Question>> GetQuestionWithAnswersByUserExamAsync(Guid examId, Guid userId);
        Task<Entities.Exam> GetExamWithPeriodsById(Guid examId);
    }
}
