using BnE.EducationVest.Domain.Exam.Entities;
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
        public static double GetUserTotalScore(this Entities.Exam exam, Guid userId, bool isEngineering, List<Question> plusQuestions)
        {
            //Criar factory
            switch (exam.ExamModel)
            {
                case EExamModel.Insper:
                case EExamModel.InsperAntiga:
                    return exam.GetUserInsperTotalPerformance(userId, isEngineering, plusQuestions);

                default: throw new NotImplementedException();
            }
        }
        public static double GetUserMathPerformance(this Entities.Exam exam, Guid userId)
        {
            return exam.Questions.Where(x => x.Subject.IsMathTopic())
                .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect());
        }
        public static double GetUserPortuguesePerformance(this Entities.Exam exam, Guid userId)
        {
            return exam.Questions.Where(x => x.Subject.IsPortugueseTopic())
                .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect());
        }
        public static double GetPlusQuestionPerformance(List<Question> questions, Guid userId)
        {
            return questions.Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect());
        }

        public static double GetUserInsperTotalPerformance(this Entities.Exam exam, Guid userId, bool isEngineering, List<Question> plusQuestions)
        {
            
            if(isEngineering)
                return 200 + ((exam.GetUserMathPerformance(userId) / exam.GetMathQuestionCount()) * 266.67
                                +
                        (exam.GetUserPortuguesePerformance(userId) / exam.GetPortugueseQuestionCount()) * 266.66
                        +
                        (GetPlusQuestionPerformance(plusQuestions, userId) / plusQuestions.Count) * 266.66);
            else
                return 200 + ((exam.GetUserMathPerformance(userId) / exam.GetMathQuestionCount()) * 400
                                +
                                (exam.GetUserPortuguesePerformance(userId) / exam.GetPortugueseQuestionCount()) * 200
                                +
                                (GetPlusQuestionPerformance(plusQuestions, userId) / plusQuestions.Count) * 200);
        }
    }
}

