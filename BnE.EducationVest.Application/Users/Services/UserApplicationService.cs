using BnE.EducationVest.Application.Users.Interface;
using BnE.EducationVest.Application.Users.ViewModels;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using BnE.EducationVest.Domain.Users.Entities;
using System.Threading.Tasks;
using BnE.EducationVest.Domain.Users.ValueObjects;
using BnE.EducationVest.Domain.Users.Interfaces.InfraData;
using Microsoft.AspNetCore.Http;
using BnE.EducationVest.Application.Common.Extensions;
using System.Linq;
using System.Net;
using System;

namespace BnE.EducationVest.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserApplicationService(IUserAuthService userAuthService, IUserRepository userRepository,
                                      IHttpContextAccessor httpContextAccessor)
        {
            _userAuthService = userAuthService;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Either<ErrorResponseModel, Guid>> AddUserAsync(CreateUserRequestModel createUserRequestModel)
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
            await _userRepository.AddAsync(user);
            return new Either<ErrorResponseModel, Guid>(user.Id, HttpStatusCode.OK);
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
            if (loginRequestModel.LoginFlow == ELoginFlow.Credentials)
                return await _userAuthService.LoginAsync(loginRequestModel.Username, loginRequestModel.Password);
            else
                return await _userAuthService.LoginRefreshTokenAsync(loginRequestModel.RefreshToken);
        }
        public async Task<Either<ErrorResponseModel, UserMenusViewModel>> GetUserMenu()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var groups = tokenData.CognitoGroups.ToList();
            //TODO: Refatorar forma de verificar grupos, está altamente acoplado com a nomenclatura do cognito
            var menus = await _userRepository.GetAvailableMenusByUserGroup(groups.Contains("Teachers"), groups.Contains("Students"));
            var user = await _userRepository.GetUserByCognitoId(Guid.Parse(tokenData.CognitoId));

            return new Either<ErrorResponseModel, UserMenusViewModel>(new UserMenusViewModel() { Name = user.Name, BirthDate = user.BirthDate,
                                                                                                Menus = menus.Select(x => new MenuViewModel() {Key = x.Key, Label = x.Label } ) }, HttpStatusCode.OK);
        }
    }
}
