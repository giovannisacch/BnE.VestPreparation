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
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Domain.Users.Interfaces;
using System.Collections.Generic;

namespace BnE.EducationVest.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserApplicationService(IUserAuthService userAuthService, IUserRepository userRepository,
                                      IHttpContextAccessor httpContextAccessor, IUserDomainService userDomainService)
        {
            _userAuthService = userAuthService;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _userDomainService = userDomainService;
        }
        public async Task<Either<ErrorResponseModel, Guid>> AddUserAsync(CreateUserRequestModel createUserRequestModel)
        {
            //Adicionar no banco de dados
            //Criar mapper
            var addressVO = new AddressVO(createUserRequestModel.Address.CEP, createUserRequestModel.Address.Street,
                                           createUserRequestModel.Address.Neighborhood, createUserRequestModel.Address.City,
                                           createUserRequestModel.Address.State);
            var user = new User(createUserRequestModel.Name, createUserRequestModel.CPF, 
                                createUserRequestModel.PhoneNumber, createUserRequestModel.Gender, createUserRequestModel.Email, 
                                createUserRequestModel.BirthDate, addressVO, createUserRequestModel.UserType);
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

            return new Either<ErrorResponseModel, UserMenusViewModel>(new UserMenusViewModel() { Name = user.Name, 
                                                                                                BirthDate = user.BirthDate, 
                                                                                                TermsWasAccepted = user.WasAcceptedTerms,
                                                                                                Menus = menus.Select(x => new MenuViewModel() {Key = x.Key, Label = x.Label } ) }, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, object>> AddExternalUserProfile(ExternalUserProfileRequestViewModel externalUserProfileRequestView)
        {
            var externalUserProfileDOmain = new ExternalUserProfile()
            {
                ExpectedCollege = externalUserProfileRequestView.ExpectedCollege,
                ExpectedCourse = externalUserProfileRequestView.ExpectedCourse,
                ActualCollege = externalUserProfileRequestView.ActualCollege,
                ActualOccupation = externalUserProfileRequestView.ActualOccupation,
                UserId = externalUserProfileRequestView.UserId
            };
            await _userRepository.AddExternalUserProfile(externalUserProfileDOmain);
            return new Either<ErrorResponseModel, object>(new {id = externalUserProfileDOmain.Id}, HttpStatusCode.OK);
        }

        public async Task AcceptUserTerms()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var user = await _userRepository.GetUserByCognitoId(Guid.Parse(tokenData.CognitoId));
            user.AcceptTerms();
            await _userRepository.UpdateAsync(user);
        }
        public async Task UpdateUserOptins(UpdateUserOptinRequestViewModel updateUserOptinRequestViewModel)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var userWithOptIns = await _userRepository.GetUserWithOptinsByIdAsync(userId);
            //Removendo os optins que não estão vindo marcados nessa API
            userWithOptIns.Optins.RemoveAll(x => !updateUserOptinRequestViewModel.CheckedOptIns.Contains(x.OptinId));
            var optinsToAdd = updateUserOptinRequestViewModel.CheckedOptIns.Where(x => !userWithOptIns.Optins.Any(opt => opt.OptinId == x)).ToList();
            optinsToAdd.ForEach(x => userWithOptIns.AddAcceptedOptin(x));
            await _userRepository.UpdateAsync(userWithOptIns);
        }
        public async Task<TermAndOptinResponseViewModel> GetUseTermAndOptins()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var optinsWithUserAccept = await _userRepository.GetOptinsAndUserAccepts(userId);
            return new TermAndOptinResponseViewModel()
            {
                Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis dapibus, ante non aliquam efficitur, tellus elit lacinia enim, in gravida odio diam at augue. Sed vel condimentum augue. Aenean dapibus consequat lobortis. Duis in sem porta nisi molestie aliquet eget et tortor. Pellentesque posuere pharetra maximus. Integer laoreet augue at massa sollicitudin, vel euismod libero vestibulum. Sed aliquet consequat neque fermentum tincidunt. In massa orci, vestibulum ac lorem nec, gravida vestibulum neque.

Suspendisse iaculis nibh at justo malesuada posuere. Maecenas vehicula eros at est euismod, blandit molestie tortor viverra. Nulla facilisi. Nunc eget odio ut risus vulputate venenatis. Morbi nibh massa, ultricies a iaculis sit amet, viverra at purus. Donec aliquet ultrices nisl, quis aliquet lacus mattis non. Morbi vel nulla at ante feugiat maximus ut quis turpis. Sed suscipit scelerisque finibus. Sed venenatis tempus lacus at aliquet. Quisque varius sem erat, eu euismod sapien lacinia eu. Suspendisse potenti. Ut tempor quam a consectetur tempor.

Suspendisse porttitor sed metus nec elementum. Donec vestibulum eget mi at aliquam. Mauris rhoncus venenatis odio, in tristique lectus. Phasellus at porta lectus. Proin sit amet lacinia erat. Proin volutpat, mi sed vehicula accumsan, nulla quam auctor ligula, sit amet pellentesque erat mi non ligula. Sed scelerisque euismod lorem, pulvinar faucibus neque lacinia ut.

Sed eu mauris at nunc gravida congue id vel enim. Curabitur pellentesque nibh nunc. Vivamus at dolor elit. In nec nisl molestie, bibendum velit non, accumsan diam. Vestibulum placerat tincidunt rhoncus. Phasellus et lobortis lorem. Pellentesque sodales nunc sed vehicula suscipit. Sed dictum mauris lacus, vel pretium massa efficitur vel. Sed varius rutrum porttitor. Quisque at condimentum nibh.

Morbi quis augue eleifend, pulvinar nunc vitae, blandit metus. Praesent eu ante nunc. Duis sed dolor eu mi pharetra vestibulum eget in justo. Sed interdum mauris pulvinar velit tincidunt ultricies. Nam non purus scelerisque, feugiat turpis nec, maximus ante. Aenean vel lobortis ligula, at auctor sapien. Mauris malesuada ornare enim id iaculis. Cras nisl ipsum, finibus tincidunt justo ut, semper bibendum tellus.",
                Optins = optinsWithUserAccept
                        .Select(x => new OptinResponseViewModel() { Id = x.Id, Text = x.Text, Checked = x.UsersAccepted == null? false : x.UsersAccepted.Any() })
                        .ToList()
            };
        }
    }
}
