using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class QuestionExamViewModel
    {
        public QuestionTextViewModel Enunciated { get; set; }
        public int Index { get; set; }
        public List<QuestionAlternativeViewModel> Alternatives { get; set; }
    }
}
