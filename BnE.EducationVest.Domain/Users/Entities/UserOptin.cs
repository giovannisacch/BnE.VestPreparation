using BnE.EducationVest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Entities
{
    public class UserOptin
    {
        public Guid UserId { get; private set; }
        public User User { get; set; }
        public int OptinId { get; private set; }
        public Optin Optin { get; set; }
        public DateTime AcceptedDate { get; private set; }

        public UserOptin(Guid userId, int optinId)
        {
            UserId = userId;
            OptinId = optinId;
            AcceptedDate = DateTime.Now;
        }
    }
}
