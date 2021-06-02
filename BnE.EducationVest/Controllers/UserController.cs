using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using BnE.EducationVest.Application.Users.Interface;
using BnE.EducationVest.Application.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnE.EducationVest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserApplicationService _userApplicationService;
        public UserController(ILogger<UserController> logger,
            IUserApplicationService userApplicationService)
        {
            _logger = logger;
            _userApplicationService = userApplicationService;
        }

        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword(FirstPasswordChangeRequestModel firstPasswordChangeRequestModel)
        {
            var response = await _userApplicationService.ChangePasswordAsAdmin(firstPasswordChangeRequestModel);

            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            var response = await _userApplicationService.LoginAsync(loginRequestModel);

            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequestModel createUserRequestModel)
        {

            var response = await _userApplicationService.AddUserAsync(createUserRequestModel);

            return StatusCode((int)response.StatusCode, 
                response.IsSuccess 
                ? new { UserId = response.SuccessResponseModel } 
                : response.ErrorResponseModel);
        }
        [HttpPost("recoverPassword")]
        public async Task<IActionResult> RecoverPassword(string username)
        {

            var response = await _userApplicationService.InitiateRecoverPassword(username);

            return StatusCode((int)response.StatusCode,
             response.IsSuccess
             ? response.SuccessResponseModel
             : response.ErrorResponseModel);
        }
        [HttpPost("recoverPasswordCode")]
        public async Task<IActionResult> ConfirmPasswordRecover(string username, string code, string newPassword)
        {

            var response = await _userApplicationService.ConfirmPasswordRecover(username, code, newPassword);

            return StatusCode((int)response.StatusCode,
                response.IsSuccess
                ? response.SuccessResponseModel
                : response.ErrorResponseModel);
        }
        [Authorize]
        [HttpGet("menus")]
        public async Task<IActionResult> GetUserMenuList()
        {

            var response = await _userApplicationService.GetUserMenu();

            return StatusCode((int)response.StatusCode,
                response.IsSuccess
                ? response.SuccessResponseModel
                : response.ErrorResponseModel);
        }
    }
}
