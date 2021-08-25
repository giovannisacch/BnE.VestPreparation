using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Enums
{
    public enum EExamTopic
    {
        [Description("Ciências Humanas")]
        HumanSciences,
        [Description("Ciências da Natureza")]
        NatureSciences,
        [Description("Linguagens e Matemática")]
        LanguagesAndMath,
        [Description(" ")]
        General
    }
}