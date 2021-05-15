using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class IncrementViewModel
    {
        public int Index { get; set; }
        public string Value { get; set; }
        public Stream ImageStream { get; set; }

        public ECompleteTextIncrementType Type { get; set; }
    }
}
