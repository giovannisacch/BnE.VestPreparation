using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Alternative 
    {
        public Guid Id { get; private set; }
        //FK
        public Guid QuestionId { get; private set; }
        public Guid TextContentId { get; private set; }
        public IncrementedTextVO TextContent { get; private set; }
        public int Index { get; private set; }
        public bool IsCorrect { get; private set; }

        public Question Question{ get; private set; }
        public List<QuestionAnswer> QuestionAnswers { get; private set; }

        internal Alternative()
        {

        }
        public Alternative(IncrementedTextVO textContent, bool isCorrect, int index)
        {
            Id = Guid.NewGuid();
            TextContent = textContent;
            IsCorrect = isCorrect;
            Index = index;
        }
    }
}
