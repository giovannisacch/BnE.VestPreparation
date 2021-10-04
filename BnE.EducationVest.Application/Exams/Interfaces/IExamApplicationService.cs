using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Application.Exams.ViewModels.Response;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Interfaces
{
    public interface IExamApplicationService
    {
        Task<Either<ErrorResponseModel, Guid>> CreateExam(ExamViewModel examViewModel, PreExamVO preExamVO);
        Task<Either<ErrorResponseModel, AvailableExamsViewModel>> GetAvailableExamsByUser();
        Task<Either<ErrorResponseModel, ExamViewModel>> GetExam(Guid examId);
        Task<Either<ErrorResponseModel, IEnumerable<ExamViewModel>>> GetAllExams();
        Task<Either<ErrorResponseModel, object>> AddExamPeriods(Guid examId, List<ExamPeriodViewModel> periods);
        Task<Either<ErrorResponseModel, Guid>> AddExamQuestionAnswer(AnswerQuestionRequestViewModel answerQuestionResponse);
        Task<Either<ErrorResponseModel, object>> UpdateExamQuestionAnswer(UpdateAnswerQuestionRequestViewModel updateAnswerQuestionResponse);
        Task<Either<ErrorResponseModel, GetExamQuestionListViewModel>> GetQuestions(GetQuestionListPaginatedRequestViewModel getQuestionListPaginatedRequest);
        Task UploadPreExam(UploadExamPeriodsRequestViewModel uploadExamPeriodsRequestViewModel);
        Task FinalizeExam(Guid ExamId);
        Task<IEnumerable<SubjectResponseViewModel>> GetSubjects();
        Task<RealizedExamListViewModel> GetUserRealizedExamList();
        Task<ExamReportViewModel> GetUserExamReport(Guid examId, Guid? studentId = null);
        Task DeleteUserAnswers(Guid examId);
        Task<SubjectEvolutionsResponseViewModel> GetEvolutional();
        Task<PreExamVO> GetPreExamVO(EExamModel examModel, EExamType examType, int number, EExamTopic examTopic);
        Task SetExamComparation(Guid examId);
        Task AddSecondsSpent(Guid questionId, long secondsSpent);
        Task<Either<ErrorResponseModel, object>> SaveExcelResultsToUserAnswers(Guid examId, IFormFile file);
        Task<object> GetReportFilters();
        Task<object> GetRealizedExamsByFilters(Guid? userId, int? examTopic, int? examModel, int? examNumber);
        Task<object> GetCreateExamFilters();
    }
}
