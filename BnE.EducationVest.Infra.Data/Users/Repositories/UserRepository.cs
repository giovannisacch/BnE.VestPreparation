using BnE.EducationVest.Domain.Users.Entities;
using BnE.EducationVest.Domain.Users.Interfaces.InfraData;
using BnE.EducationVest.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Users.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EducationVestContext context) : base(context)
        {
        }
        public async Task<List<UserMenu>> GetAvailableMenusByUserGroup(bool isTeacher, bool isStudent)
        {
            return await _context
                          .UserMenus
                          .Where(x => x.ToStudent == isStudent || x.ToTeacher == isTeacher)
                          .ToListAsync();
        }

        public async Task<User> GetUserByCognitoId(Guid cognitoId)
        {
            return await _db.FirstAsync(x => x.CognitoUserId == cognitoId);
        }
    }
}
