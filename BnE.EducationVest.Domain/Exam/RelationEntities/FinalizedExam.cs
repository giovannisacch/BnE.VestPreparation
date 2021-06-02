using BnE.EducationVest.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.RelationEntities
{
    public class FinalizedExam
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid ExamId { get; private set; }
        public Entities.Exam Exam { get; private set; }
        public DateTime FinalizedDate { get; private set; }

        public FinalizedExam(Guid userId, Guid examId)
        {
            UserId = userId;
            ExamId = examId;
            FinalizedDate = DateTime.Now;
        }
    }
}
