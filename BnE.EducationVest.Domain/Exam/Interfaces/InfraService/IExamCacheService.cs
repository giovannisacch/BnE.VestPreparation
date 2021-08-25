using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
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
        Task DeleteUserStartedExam(Guid userId, Guid examId);
        Task<List<Question>> GetQuestionsByPageAsync(Guid examId, int page);
        Task SaveQuestionListByPage(Entities.Exam exam, List<Question> questionList, int page);
        Task SavePreExam(PreExamVO preExamVO);
        Task<PreExamVO> GetPreExam(EExamModel examModel, EExamType examType, int number, EExamTopic examTopic);
    }
}
