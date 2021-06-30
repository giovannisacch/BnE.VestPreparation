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
        Task SaveExamPeriodsAndSubjects(EExamModel examModel,EExamType examType, int number, List<ExamPeriodVO> periods, List<Guid> subjectIdList);
        Task<List<ExamPeriodVO>> GetExamPeriods(EExamModel examModel, EExamType examType, int number);
        Task<List<Guid>> GetExamSubjects(EExamModel examModel, EExamType examType, int number);
    }
}
