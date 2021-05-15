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
    }
}
