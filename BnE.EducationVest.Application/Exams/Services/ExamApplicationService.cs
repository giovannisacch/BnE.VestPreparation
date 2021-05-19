using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.Mappings;
using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Services
{
    public class ExamApplicationService : IExamApplicationService
    {
        private readonly IExamRepository _examRepository;
        public ExamApplicationService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
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
        public async Task<IEnumerable<ExamViewModel>> GetAllExams()
        {
            var examList = await _examRepository.FindAllAsync(true);
            return examList.Select(x => x.MapToViewModel());
        }
        public async Task<AvailableExamsViewModel> GetAvailableExamsByUser()
        {
            //TODO: VERIFICAR SE USUARIO JA SUBMETEU OU COMEÇOU O SIMULADO
            var availableExams = await _examRepository.GetAvailableExams();
            var response = new AvailableExamsViewModel();
            response.AvailableExams = availableExams.Select(x => new AvailableExamViewModel()
            {
                ExamId = x.Id,
                ExamName = $"Simulado {x.ExamNumber} - {Enum.GetName(typeof(EExamType), x.ExamType)}",
                ExpirationDate = x.GetActualAvailablePeriod().CloseDate
            });

            return response;
        }
        
        public async Task<ExamViewModel> GetExam(Guid examId)
        {
            var exam = await _examRepository.GetByIdWithAllIncludes(examId);
            return exam.MapToViewModel();
        }
        public async Task AddExamPeriods(Guid examId, List<ExamPeriodViewModel> periods)
        {
            var exam = await _examRepository.FindByIdAsync(examId);

            periods.ForEach(period =>
                exam.AddPeriod(period.OpenDate, period.CloseDate)
            );

            await _examRepository.UpdateAsync(exam);
        }
    }
}
