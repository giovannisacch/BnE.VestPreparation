using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class GetExamQuestionListViewModel
    {
        public IEnumerable<QuestionExamViewModel> Questions { get; set; }
    }
}
