using System;
using System.Collections.Generic;

namespace BnE.EducationVest.Domain.Users.Entities
{
    public class Optin
    {
        public int Id { get; set; }
        public string Text { get; private set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public List<UserOptin> UsersAccepted { get; set; }

    }
}
