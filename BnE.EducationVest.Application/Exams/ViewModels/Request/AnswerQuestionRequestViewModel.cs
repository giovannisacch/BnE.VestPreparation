using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels.Response
{
    public class AnswerQuestionRequestViewModel
    {
        public Guid ExamId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid ChosenAlternativeId { get; set; }
    }
}
