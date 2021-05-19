using System;
using System.Collections.Generic;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class QuestionExamViewModel
    {
        public Guid QuestionId { get; set; }
        public QuestionTextViewModel Enunciated { get; set; }
        public int Index { get; set; }
        public List<QuestionAlternativeViewModel> Alternatives { get; set; }
        public Guid SubjectId { get; set; }
    }
}
