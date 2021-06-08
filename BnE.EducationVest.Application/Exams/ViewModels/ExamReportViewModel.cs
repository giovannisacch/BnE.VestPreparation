using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class ExamReportViewModel
    {
        public IEnumerable<ExamReportPerformanceViewModel> MyPerformances { get; set; }
        public IEnumerable<ExamReportSubjectDifficultyViewModel> SubjectsDifficulties { get; set; }
        public IEnumerable<ExamReportSubjectDistributionViewModel> SubjectsDistribution { get; set; }
        public IEnumerable<ExamReportAcertsAndErrorBySubject> AcertsAndErrorsBySubject { get; set; }
        public IEnumerable<ExamReportAcertsAndErrorByQuestion> AcertsAndErrorsByQuestion { get; set; }
    }
    public class ExamReportPerformanceViewModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
    public class ExamReportSubjectDifficultyViewModel
    {
        public string Name { get; set; }
        public string Easy { get; set; }
        public string Medium { get; set; }
        public string Hard { get; set; }
    }
    public class ExamReportSubjectDistributionViewModel
    {
        public string Name { get; set; }
        public IEnumerable<int> QuestionNumbers { get; set; }
    }
    public class ExamReportAcertsAndErrorBySubject
    {
        public string Subject { get; set; }
        public int QuestionCount { get; set; }
        public int CorrectCount { get; set; }
    }
    public class ExamReportAcertsAndErrorByQuestion
    {
        public int QuestionNumber { get; set; }
        public string Subject { get; set; }
        public string ChosenAlternative { get; set; }
        public string RightAlternative { get; set; }
        public string Difficulty { get; set; }
    }
}
