using BnE.EducationVest.Application.Exams.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Interfaces
{
    public interface IExamApplicationService
    {
        Task<Guid> CreateExam(ExamViewModel examViewModel);
        Task<AvailableExamsViewModel> GetAvailableExamsByUser();
        Task<ExamViewModel> GetExam(Guid examId);
        Task<IEnumerable<ExamViewModel>> GetAllExams();
        Task AddExamPeriods(Guid examId, List<ExamPeriodViewModel> periods);
    }
}
