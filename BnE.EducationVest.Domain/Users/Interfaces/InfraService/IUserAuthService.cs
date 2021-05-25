using BnE.EducationVest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Users.Interfaces.InfraService
{
    public interface IUserAuthService
    {
        Task CreateUserAsync(Entities.User user);
        Task<Either<ErrorResponseModel, object>> AdminUpdateUserPasswordAsync(string username, string password, string oldPassword);
        Task<Either<ErrorResponseModel, object>> LoginAsync(string username, string password);
        Task<Either<ErrorResponseModel, object>> LoginRefreshTokenAsync(string refreshToken);
        Task<Either<ErrorResponseModel, object>> SendForgotPasswordCodeAsync(string username);
        Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword);
    }
}
