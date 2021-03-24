using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using BnE.EducationVest.Application.Users.Interface;
using BnE.EducationVest.Application.Users.Services;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using BnE.EducationVest.Infra.Service.User.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.DI
{
    public static class DependencyInjectionBuilder
    {

        public static void InjectApplicationServiceDependencies(this IServiceCollection services) 
        {
            services.AddScoped<IUserApplicationService, UserApplicationService>();
        }

        public static void InjectInfraServiceDependencies(this IServiceCollection services)
        {
            var aa = new AmazonCognitoIdentityProviderClient("AKIAWOALMJU6CKZG6LU3", "N0YPZzRATQ3TS5xSDTkc2dBOwoJ858kp5xtjU9Od", RegionEndpoint.SAEast1);
            var cognitoUserPool = new CognitoUserPool("sa-east-1_DFZtMc2ZI", "14cju6jccv85qh47oh5ta2629i", aa);
            services.AddSingleton<IAmazonCognitoIdentityProvider>(aa);
            services.AddSingleton(cognitoUserPool);
            services.AddScoped<IUserAuthService, UserAuthService>();
        }
    }
}
