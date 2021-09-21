using BnE.EducationVest.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Interfaces
{
    public interface IUserDomainService
    {
        Task<Guid> GetUserIdByCognitoId(Guid cognitoId);
        Task<List<User>> GetAllUsersInEmailList(List<string> userList);
        Task<List<User>> GetUsersAsync();
    }
}
