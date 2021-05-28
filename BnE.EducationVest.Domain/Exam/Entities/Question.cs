using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Question : EntityBase
    {
        //FK
        public Guid ExamId { get; set; }
        public Guid EnunciatedId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid? SupportingTextId { get; set; }
        public int Index { get; private set; }
        public IncrementedTextVO Enunciated { get; private set; }
        public List<Alternative> Alternatives { get; private set; }
        public List<QuestionAnswer> QuestionAnswers { get; private set; }
        public Exam Exam { get; private set; }
        public Subject Subject{ get; set; }
        public SupportingText SupportingText { get; set; }
        internal Question()
        {

        }
        public Question(int index, IncrementedTextVO enunciated, List<Alternative> alternatives, Guid subjectId)
        {
            Index = index;
            Enunciated = enunciated;
            SetAlternatives(alternatives);
            SubjectId = subjectId;
        }
        public bool HasImageInEnunciated()
        {
            return Enunciated.GetIncrementsWithImageType() != null;
        }
        public void SetAlternatives(List<Alternative> alternatives)
        {
            if (alternatives.Count != 5)
                throw new DomainErrorException(ErrorConstants.ALTERNATIVE_COUNT_SHOULD_BE_FIVE);
            Alternatives = alternatives;
        }
        public void SetSupportingText(SupportingText supportingText)
        {
            SupportingText = supportingText;
        }
    }
}
