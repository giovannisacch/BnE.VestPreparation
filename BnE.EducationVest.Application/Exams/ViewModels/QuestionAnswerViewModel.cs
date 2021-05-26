using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class QuestionAnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public Guid ChosenAlternativeId { get; set; }
    }
}
