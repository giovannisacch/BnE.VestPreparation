﻿using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Application.Users.ViewModels;
using BnE.EducationVest.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Users.Interface
{
    public interface IUserApplicationService
    {
        Task<Either<ErrorResponseModel, Guid>> AddUserAsync(CreateUserRequestModel createUserRequestModel);
        Task<Either<ErrorResponseModel, object>> LoginAsync(LoginRequestModel loginRequestModel);
        Task<Either<ErrorResponseModel, object>> ChangePasswordAsAdmin(FirstPasswordChangeRequestModel userNameAndPasswordRequestModel);
        Task<Either<ErrorResponseModel, object>> InitiateRecoverPassword(string username);
        Task<Either<ErrorResponseModel, object>> ConfirmPasswordRecover(string username, string code, string newPassword);
        Task<Either<ErrorResponseModel, UserMenusViewModel>> GetUserMenu();
        Task<Either<ErrorResponseModel, object>> AddExternalUserProfile(ExternalUserProfileRequestViewModel externalUserProfileRequestView);
        Task AcceptUserTerms();
        Task UpdateUserOptins(UpdateUserOptinRequestViewModel updateUserOptinRequestViewModel);
        Task<TermAndOptinResponseViewModel> GetUseTermAndOptins();
        Task DeleteUser();

        Task<Either<ErrorResponseModel, object>> CreateUsersBuk(IFormFile file);
    }
}
