using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class QuestionTextViewModel
    {
        public string Content { get; set; }
        public List<IncrementViewModel> Increments { get; set; }
    }
}
