using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class CompleteTextVO
    {
        public string Content { get; private set; }
        public List<CompleteTextIncrementVO> Increments { get; private set; }
    }
}
