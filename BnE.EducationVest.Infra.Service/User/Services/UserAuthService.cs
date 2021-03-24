using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using BnE.EducationVest.Domain;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.User.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IAmazonCognitoIdentityProvider _amazonCognitoIdentityProviderClient;
        private readonly CognitoUserPool _cognitoUserPool;

        public UserAuthService(IAmazonCognitoIdentityProvider amazonCognitoIdentityProviderClient, CognitoUserPool cognitoUserPool)
        {
            _amazonCognitoIdentityProviderClient = amazonCognitoIdentityProviderClient;
            _cognitoUserPool = cognitoUserPool;
        }

        public async Task CreateUserAsync(Domain.Users.Entities.User user)
        {
            var adminCreateUseRequest = new AdminCreateUserRequest()
            {
                DesiredDeliveryMediums = new List<string> { "EMAIL" },
                //Atributos com nome com espaco devem estar juntos, ex middlename e updatedat
                UserPoolId = _cognitoUserPool.PoolID,
                Username = user.Email,
                TemporaryPassword = "Mudar123",
                UserAttributes = GetUserAttributesByUserEntity(user)
            };

            var result = await _amazonCognitoIdentityProviderClient.AdminCreateUserAsync(adminCreateUseRequest);

            await _amazonCognitoIdentityProviderClient.AdminAddUserToGroupAsync(
              new AdminAddUserToGroupRequest
              {
                  GroupName = user.IsTeacher ? "Teachers" : "Students",
                  Username = user.Email,
                  UserPoolId = _cognitoUserPool.PoolID
              });

            user.CognitoUserId = result.User.Username;
        }

        public async Task<Either<ErrorResponseModel, object>> AdminUpdateUserPasswordAsync(string username, string newPassword, string oldPassword)
        {
            var loginTry = await LoginAsync(username, oldPassword);
            if (string.IsNullOrEmpty(loginTry.ErrorResponseModel?.Message) 
                || loginTry.ErrorResponseModel?.Message != ErrorConstants.NEW_PASSWORD_REQUIRED)
                //TODO: Criar constants
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(ErrorConstants.SHOULD_BE_FIRST_PASSWORD_CHANGE), 
                                                                System.Net.HttpStatusCode.BadRequest);
            var passwordRequest = new AdminSetUserPasswordRequest()
            {
                Password = newPassword,
                Permanent = true,
                Username = username,
                UserPoolId = _cognitoUserPool.PoolID
            };
            var response = await _amazonCognitoIdentityProviderClient.AdminSetUserPasswordAsync(passwordRequest);
            //Verificar como colocar erro(investigar erros do updateUser, as excep´tions criar handler para exceptions da aws)
            return new Either<ErrorResponseModel, object>(null, response.HttpStatusCode);
        }
        public async Task<Either<ErrorResponseModel, object>> LoginAsync(string username, string password)
        {
            var request = new AdminInitiateAuthRequest
            {
                UserPoolId = _cognitoUserPool.PoolID,
                ClientId = _cognitoUserPool.ClientID,
                AuthFlow = AuthFlowType.ADMIN_USER_PASSWORD_AUTH
            };

            request.AuthParameters.Add("USERNAME", username);
            request.AuthParameters.Add("PASSWORD", password);

            var response = await _amazonCognitoIdentityProviderClient.AdminInitiateAuthAsync(request);
            if (response.AuthenticationResult == null)
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(response.ChallengeName), System.Net.HttpStatusCode.BadRequest);
            return new Either<ErrorResponseModel, object>(response.AuthenticationResult, response.HttpStatusCode);
        }
        private List<AttributeType> GetUserAttributesByUserEntity(Domain.Users.Entities.User user)
        {
            long unixStart = (long)DateTime.Now
                                    .ToUniversalTime()
                                    .Subtract(DateTime.UnixEpoch)
                                    .TotalSeconds;
            var userAttributes = new List<AttributeType>
                    {
                        new AttributeType()
                        {
                            Name = "phone_number",
                            Value = user.PhoneNumber
                        },
                         new AttributeType()
                        {
                            Name = "name",
                            Value = user.Name.Split(' ')[0]
                        },
                        new AttributeType()
                        {
                            Name = "middle_name",
                            Value = user.Name.Split(' ')[1]
                        },
                        new AttributeType()
                        {
                            Name = "gender",
                            Value = user.Gender
                        },
                        new AttributeType()
                        {
                            Name = "email",
                            Value = user.Email
                        },
                        new AttributeType()
                        {
                            Name = "birthdate",
                            Value = user.BirthDate.ToString("YYYY/MM/dd")
                        },
                         new AttributeType()
                        {
                            Name = "address",
                            Value = user.Address.Street
                        },
                          new AttributeType()
                        {
                            Name = "custom:custom:CPF",
                            Value = user.CPF
                        },
                          new AttributeType()
                        {
                            Name = "updated_at",
                            Value = unixStart.ToString()
                        },
                    };
            return userAttributes;
        }
    }
}
