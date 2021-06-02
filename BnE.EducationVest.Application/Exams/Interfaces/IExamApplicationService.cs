using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Application.Exams.ViewModels.Response;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Interfaces
{
    public interface IExamApplicationService
    {
        Task<Either<ErrorResponseModel, Guid>> CreateExam(ExamViewModel examViewModel);
        Task<Either<ErrorResponseModel, AvailableExamsViewModel>> GetAvailableExamsByUser();
        Task<Either<ErrorResponseModel, ExamViewModel>> GetExam(Guid examId);
        Task<Either<ErrorResponseModel, IEnumerable<ExamViewModel>>> GetAllExams();
        Task<Either<ErrorResponseModel, object>> AddExamPeriods(Guid examId, List<ExamPeriodViewModel> periods);
        Task<Either<ErrorResponseModel, Guid>> AddExamQuestionAnswer(AnswerQuestionRequestViewModel answerQuestionResponse);
        Task<Either<ErrorResponseModel, object>> UpdateExamQuestionAnswer(UpdateAnswerQuestionRequestViewModel updateAnswerQuestionResponse);
        Task<Either<ErrorResponseModel, GetExamQuestionListViewModel>> GetQuestions(GetQuestionListPaginatedRequestViewModel getQuestionListPaginatedRequest);
        Task UploadExamPeriods(UploadExamPeriodsRequestViewModel uploadExamPeriodsRequestViewModel);
        Task<List<ExamPeriodViewModel>> GetExamPeriods(EExamModel examModel, EExamType examType, int number);
        Task FinalizeExam(Guid ExamId);
    }
}
