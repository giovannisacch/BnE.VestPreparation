using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Alternative 
    {
        //FK
        public Guid QuestionId { get; private set; }
        public Guid TextContentId { get; set; }
        public IncrementedTextVO TextContent { get; private set; }
        public int Index { get; set; }
        public bool IsCorrect { get; private set; }

        public Question Question{ get; private set; }
        internal Alternative()
        {

        }
        public Alternative(IncrementedTextVO textContent, bool isCorrect, int index)
        {
            TextContent = textContent;
            IsCorrect = isCorrect;
            Index = index;
        }
    }
}
