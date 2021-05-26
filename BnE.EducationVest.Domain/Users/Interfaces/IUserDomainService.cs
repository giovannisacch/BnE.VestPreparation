using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Interfaces
{
    public interface IUserDomainService
    {
        public Task<Guid> GetUserIdByCognitoId(Guid cognitoId);
    }
}
