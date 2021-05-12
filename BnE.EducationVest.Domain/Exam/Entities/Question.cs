using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Question : EntityBase
    {
        public Guid ExamId { get; private set; }
        public int Index { get; private set; }
        public CompleteTextVO Enunciated { get; private set; }
        public List<Alternative> Alternatives { get; private set; }

        public Exam Exam { get; private set; }

        public Question(Guid examId, int index, CompleteTextVO enunciated, List<Alternative> alternatives)
        {
            ExamId = examId;
            Index = index;
            Enunciated = enunciated;
            Alternatives = alternatives;
        }
    }
}
