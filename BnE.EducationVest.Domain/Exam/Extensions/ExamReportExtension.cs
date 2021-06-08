using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Extensions
{
    public static class ExamReportExtension
    {
        public static double GetUserTotalScore(this Entities.Exam exam, Guid userId)
        {
            //Criar factory
            switch (exam.ExamModel)
            {
                case EExamModel.Insper:
                case EExamModel.InsperAntiga:
                    return exam.GetUserInsperTotalPerformance(userId);

                default: throw new NotImplementedException();
            }
        }
        public static double GetUserMathPerformance(this Entities.Exam exam, Guid userId)
        {
            return exam.Questions.Where(x => x.Subject.IsMathTopic())
                .Count(x => x.GetUserAnswer(userId).IsCorrect());
        }
        public static double GetUserPortuguesePerformance(this Entities.Exam exam, Guid userId)
        {
            return exam.Questions.Where(x => x.Subject.IsPortugueseTopic())
                .Count(x => x.GetUserAnswer(userId).IsCorrect());
        }
        private static double GetUserInsperTotalPerformance(this Entities.Exam exam, Guid userId)
        {
            return 200 + ( (exam.GetUserMathPerformance(userId) / exam.GetMathQuestionCount()) * 560 
                            + 
           (exam.GetUserPortuguesePerformance(userId) / exam.GetPortugueseQuestionCount()) * 240);
        }
    }
}

