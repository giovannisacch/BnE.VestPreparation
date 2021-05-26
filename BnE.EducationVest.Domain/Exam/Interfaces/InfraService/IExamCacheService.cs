using BnE.EducationVest.Domain.Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.InfraService
{
    public interface IExamCacheService
    {
        Task SaveUserStartedExam(Guid userId, Entities.Exam exam);
        Task<bool> VerifyIfUserStartedExam(Guid userId, Guid examId);
        Task<List<Question>> GetQuestionsByPageAsync(Guid examId, int page);
        Task SaveQuestionListByPage(Entities.Exam exam, List<Question> questionList, int page);
    }
}
