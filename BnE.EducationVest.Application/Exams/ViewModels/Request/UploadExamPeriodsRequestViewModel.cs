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
        public List<QuestionDetail> QuestionDetails { get; set; }
        public EExamModel ExamModel { get; set; }
        public EExamType ExamType { get; set; }
        public EExamTopic ExamTopic { get; set; }
        public int ExamNumber { get; set; }
        public string Link { get; set; }
        public Guid? ExamFatherId { get; set; }
    }
    public class QuestionDetail
    {
        public Guid Subject { get; set; }
        public int RightAnswerIndex { get; set; }
    }
}
