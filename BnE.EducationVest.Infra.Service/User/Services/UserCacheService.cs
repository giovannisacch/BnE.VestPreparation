using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.User.Services
{
    public class UserCacheService : IUserCacheService
    {
        private readonly IDistributedCache _cache;
        private readonly string _userIdByCognitoPrefix = "useridByCognitoId:";
        public UserCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SaveUserIdByCognitoId(Guid userId, Guid cognitoId)
        {
            var options = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(520)
            };
            await _cache.SetStringAsync(_userIdByCognitoPrefix + cognitoId.ToString(), userId.ToString(), options);
        }
        public async Task<Guid> GetUserIdByCognitoId(Guid cognitoId)
        {
            var userId = await _cache.GetStringAsync(_userIdByCognitoPrefix + cognitoId.ToString());
            if (string.IsNullOrEmpty(userId))
                return Guid.Empty;
            return Guid.Parse(userId);
        }
    }
}
