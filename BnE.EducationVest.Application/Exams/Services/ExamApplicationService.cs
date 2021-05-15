using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.Mappings;
using BnE.EducationVest.Application.Exams.ViewModels;
using System;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Services
{
    public class ExamApplicationService : IExamApplicationService
    {
        public ExamApplicationService()
        {
        }
        public Task<Guid> CreateExam(ExamViewModel examViewModel)
        {
            var examPeriod = new ExamPeriodViewModel()
            {
                OpenDate = DateTime.Now,
                CloseDate = DateTime.Now
            };
            var exam = examViewModel.MapToDomain();
            throw new NotImplementedException();
        }
    }
}
