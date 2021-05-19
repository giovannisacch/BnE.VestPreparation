using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class AvailableExamsViewModel
    {
        public IEnumerable<AvailableExamViewModel> AvailableExams { get; set; }
    }
    public class AvailableExamViewModel
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
