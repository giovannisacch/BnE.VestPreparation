using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels.Request
{
    public class ExternalUserProfileRequestViewModel
    {
        public Guid UserId { get; set; }
        public string ExpectedCollege { get; set; }
        public string ExpectedCourse { get; set; }
        public string ActualOccupation { get; set; }
        public string ActualCollege { get; set; }
    }
}
