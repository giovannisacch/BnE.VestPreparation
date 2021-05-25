using BnE.EducationVest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Entities
{
    public class UserMenu : EntityBase
    {
        public string Name { get; set; }
        public bool ToTeacher { get; set; }
        public bool ToStudent { get; set; }
    }
}
