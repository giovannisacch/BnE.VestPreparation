using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Users.ViewModels
{
    public class FirstPasswordChangeRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
