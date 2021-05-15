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
        //FK
        public Guid EnunciatedId { get; set; }
        public int Index { get; private set; }
        public IncrementedTextVO Enunciated { get; private set; }
        public List<Alternative> Alternatives { get; private set; }
        public Exam Exam { get; private set; }
        internal Question()
        {

        }
        public Question(int index, IncrementedTextVO enunciated, List<Alternative> alternatives)
        {
            Index = index;
            Enunciated = enunciated;
            SetAlternatives(alternatives);
        }
        public void SetAlternatives(List<Alternative> alternatives)
        {
            if (alternatives.Count != 5)
                throw new DomainErrorException(ErrorConstants.ALTERNATIVE_COUNT_SHOULD_BE_FIVE);
            Alternatives = alternatives;
        }
    }
}
