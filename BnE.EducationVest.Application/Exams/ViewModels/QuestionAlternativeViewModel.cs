using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class QuestionAlternativeViewModel
    {
        public Guid AlternativeId { get; set; }
        public QuestionTextViewModel Text { get; set; }
        public bool IsCorrect { get; set; }
        public int Index { get; set; }
    }
}
