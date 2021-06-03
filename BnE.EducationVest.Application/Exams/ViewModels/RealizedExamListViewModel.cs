using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class RealizedExamListViewModel
    {
        public IEnumerable<RealizedExamViewModel> RealizedExams { get; set; }
    }
    public class RealizedExamViewModel 
    {
        public Guid ExamId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
