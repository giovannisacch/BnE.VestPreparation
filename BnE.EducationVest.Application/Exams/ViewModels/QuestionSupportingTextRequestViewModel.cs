using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class QuestionSupportingTextRequestViewModel
    {
        public QuestionTextViewModel Text { get; set; }
        public IEnumerable<int> Questions { get; set; }
    }
}
