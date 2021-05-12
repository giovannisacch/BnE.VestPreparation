using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Alternative 
    {
        //FK
        public Guid ExamId { get; private set; }
        public CompleteTextVO TextContent { get; private set; }
        public bool IsCorrect { get; private set; }

        public Exam Exam{ get; private set; }

        public Alternative(Guid examId, CompleteTextVO textContent, bool isCorrect)
        {
            ExamId = examId;
            TextContent = textContent;
            IsCorrect = isCorrect;
        }
    }
}
