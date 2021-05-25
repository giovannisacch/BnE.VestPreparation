using BnE.EducationVest.Domain.Common.Infra;
using BnE.EducationVest.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Interfaces.InfraData
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<UserMenu>> GetAvailableMenusByUserGroup(bool isTeacher, bool isStudent);
    }
}
