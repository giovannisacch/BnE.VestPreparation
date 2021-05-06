using BnE.EducationVest.Application.Users.ViewModels;
using BnE.EducationVest.Domain.Common;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Users.Interface
{
    public interface IUserApplicationService
    {
        Task<Either<ErrorResponseModel, object>> AddUserAsync(CreateUserRequestModel createUserRequestModel);
        Task<Either<ErrorResponseModel, object>> LoginAsync(LoginRequestModel loginRequestModel);
        Task<Either<ErrorResponseModel, object>> ChangePasswordAsAdmin(FirstPasswordChangeRequestModel userNameAndPasswordRequestModel);
        Task<Either<ErrorResponseModel, object>> InitiateRecoverPassword(string username);
        Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword); 
    }
}
