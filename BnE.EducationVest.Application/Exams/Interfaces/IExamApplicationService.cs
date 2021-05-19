using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Domain.Common;
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
    }
}
