using BnE.EducationVest.Domain.Exam.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces
{
    public interface IExamDomainService
    {
        Task<List<Question>> GetExamQuestionsWithAnswers(Guid examId, Guid userId, int pageNumber, bool userAlreadyStarted);
        Task AnswerExamQuestion(Guid examId, QuestionAnswer questionAnswer);
    }
}
