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

        public async Task AddExternalUserProfile(ExternalUserProfile externalUserProfile)
        {
            await _context
                .ExternalUserProfiles
                .AddAsync(externalUserProfile);
            await _context.Commit();
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
        public async Task<User> GetUserWithOptinsByIdAsync(Guid userId)
        {
            return await _db.Include(x => x.Optins).FirstAsync(x => x.Id == userId);
        }
        public async Task<List<Optin>> GetOptinsAndUserAccepts(Guid userId)
        {
            return await _context
                            .Optins
                            .Include(x => x.UsersAccepted.Where(x => x.UserId == userId))
                            .ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<List<User>> GetUsersByEmailList(List<string> emailList)
        {
            return await _db.Where(x => emailList.Contains(x.Email)).ToListAsync();
        }
    }
}
