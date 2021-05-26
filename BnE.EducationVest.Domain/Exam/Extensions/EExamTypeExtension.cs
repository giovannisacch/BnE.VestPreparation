using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Extensions
{
    public static class EExamTypeExtension
    {
        public static int GetQuestionAmount(this EExamType examType) 
        {
            switch (examType)
            {
                case EExamType.Insper:
                    return 60;
                case EExamType.FGV:
                    return 71;
                case EExamType.Quiz:
                    return 60;
                case EExamType.InsperAntiga:
                    return 50;
                default:
                    return 60;
            }
        }
    }
}
