using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class CompleteTextIncrementVO
    {
        public int Index { get; private set; }
        public string Value { get; private set; }
        public ECompleteTextIncrementType Type { get; private set; }
    }
}
