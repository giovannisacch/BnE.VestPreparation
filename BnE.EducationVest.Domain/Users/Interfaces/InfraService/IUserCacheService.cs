using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Interfaces.InfraService
{
    public interface IUserCacheService
    {
        Task SaveUserIdByCognitoId(Guid userId, Guid cognitoId);
        Task<Guid> GetUserIdByCognitoId(Guid cognitoId);
    }
}
