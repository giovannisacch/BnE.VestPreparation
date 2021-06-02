using BnE.EducationVest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Entities
{
    public class ExternalUserProfile : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string ExpectedCollege { get; set; }
        public string ExpectedCourse { get; set; }
        public string ActualOccupation { get; set; }
        public string ActualCollege { get; set; }
    }
}
