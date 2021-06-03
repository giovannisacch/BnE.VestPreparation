using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Extensions
{
    public static class EExamModelExtension
    {
        public static int GetQuestionAmount(this EExamModel examModel) 
        {
            switch (examModel)
            {
                case EExamModel.Insper:
                    return 60;
                case EExamModel.FGV:
                    return 60;
                case EExamModel.InsperAntiga:
                    return 50;
                default:
                    return 60;
            }
        }
    }
}
