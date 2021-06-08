using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Users.Entities;
using System;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class QuestionAnswer : EntityBase
    {
        public Guid QuestionId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ChosenAlternativeId { get; private set; }

        public Question Question { get; private set; }
        public User User { get; private set; }
        public Alternative ChosenAlternative { get; private set; }

        internal QuestionAnswer()
        {

        }
        public QuestionAnswer(Guid questionId, Guid userId, Guid chosenAlternativeId)
        {
            QuestionId = questionId;
            UserId = userId;
            ChosenAlternativeId = chosenAlternativeId;
        }
        public void UpdateChosenAlternative(Guid chosenAlternativeId)
        {
            ChosenAlternativeId = chosenAlternativeId;
        }
        public bool IsCorrect()
        {
            return ChosenAlternative.IsCorrect;
        }
    }
}
