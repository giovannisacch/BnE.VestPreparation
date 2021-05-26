using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels.Response
{
    public class GetQuestionListPaginatedRequestViewModel
    {
        public Guid ExamId { get; set; }
        public int Page { get; set; }
        public bool WasStarted { get; set; }
    }
}
