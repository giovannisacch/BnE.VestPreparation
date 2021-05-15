using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class ExamViewModel
    {
        public int ExamNumber { get; set; }
        public EExamType ExamType { get; set; }
        public List<QuestionExamViewModel> QuestionList { get; set; }
        public List<ExamPeriodViewModel> Periods { get; set; }
    }
}
