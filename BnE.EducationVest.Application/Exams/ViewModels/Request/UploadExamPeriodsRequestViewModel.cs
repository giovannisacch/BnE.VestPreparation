using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels.Request
{
    public class UploadExamPeriodsRequestViewModel
    {
        public List<ExamPeriodViewModel> ExamPeriods { get; set; }
        public List<Guid> Subjects { get; set; }
        public EExamModel ExamModel { get; set; }
        public EExamType ExamType { get; set; }
        public int ExamNumber { get; set; }
    }
}
