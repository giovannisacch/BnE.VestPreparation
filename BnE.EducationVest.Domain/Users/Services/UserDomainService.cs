using BnE.EducationVest.Domain.Users.Interfaces;
using BnE.EducationVest.Domain.Users.Interfaces.InfraData;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using System;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserCacheService _userCacheService;
        private readonly IUserRepository _userRepository;
        public UserDomainService(IUserCacheService userCacheService, IUserRepository userRepository)
        {
            _userCacheService = userCacheService;
            _userRepository = userRepository;
        }

        public async Task<Guid> GetUserIdByCognitoId(Guid cognitoId)
        {
            var userId = await _userCacheService.GetUserIdByCognitoId(cognitoId);
            if (userId == Guid.Empty)
            {
                var user = await _userRepository.GetUserByCognitoId(cognitoId);
                userId = user.Id;
                await _userCacheService.SaveUserIdByCognitoId(userId, cognitoId);
            }
            return userId;
        }
    }
}
