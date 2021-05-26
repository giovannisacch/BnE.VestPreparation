using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels.Response
{
    public class UpdateAnswerQuestionRequestViewModel
    {
        public Guid QuestionAnswerId { get; set; }
        public Guid ChosenAlternativeId { get; set; }
    }
}
