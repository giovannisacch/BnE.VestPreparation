using BnE.EducationVest.Application.Users.Interface;
using BnE.EducationVest.Application.Users.ViewModels;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using BnE.EducationVest.Domain.Users.Entities;
using System.Threading.Tasks;
using BnE.EducationVest.Domain.Users.ValueObjects;

namespace BnE.EducationVest.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserAuthService _userAuthService;
        public UserApplicationService(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }
        public async Task<Either<ErrorResponseModel, object>> AddUserAsync(CreateUserRequestModel createUserRequestModel)
        {
            //Adicionar no banco de dados
            //Criar mapper
            var addressVO = new AddressVO(createUserRequestModel.Address.CEP, createUserRequestModel.Address.Street,
                                           createUserRequestModel.Address.Neighborhood, createUserRequestModel.Address.City,
                                           createUserRequestModel.Address.State, createUserRequestModel.Address.Number);
            var user = new User(createUserRequestModel.Name, createUserRequestModel.CPF, 
                                createUserRequestModel.PhoneNumber, createUserRequestModel.Gender, createUserRequestModel.Email, 
                                createUserRequestModel.BirthDate, addressVO, createUserRequestModel.IsTeacher);
            await _userAuthService.CreateUserAsync(user);
            return null;
        }

        public async Task<Either<ErrorResponseModel, object>> ChangePasswordAsAdmin(FirstPasswordChangeRequestModel firstPasswordChangeRequestModel)
        {
            return await _userAuthService
                .AdminUpdateUserPasswordAsync(firstPasswordChangeRequestModel.Username, 
                                              firstPasswordChangeRequestModel.Password, firstPasswordChangeRequestModel.OldPassword);

            //Atualizar propriedade active no banco e dados
        }

        public async Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword)
        {
            
            return await _userAuthService.ConfirmPasswordRecover(username, code, newPassword);
        }

        public async Task<Either<ErrorResponseModel, object>> InitiateRecoverPassword(string username)
        {
            return await _userAuthService.SendForgotPasswordCodeAsync(username);
        }

        public async Task<Either<ErrorResponseModel, object>> LoginAsync(LoginRequestModel loginRequestModel)
        {
            return await _userAuthService.LoginAsync(loginRequestModel.Username, loginRequestModel.Password);
        }
    }
}
