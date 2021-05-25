using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.Services;
using BnE.EducationVest.Application.Users.Interface;
using BnE.EducationVest.Application.Users.Services;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Common.SettingsModels;
using BnE.EducationVest.Domain.Users.Interfaces.InfraService;
using BnE.EducationVest.Infra.Service.Common;
using BnE.EducationVest.Infra.Service.User.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BnE.EducationVest.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Infra.Data.Exams.Repositories;
using BnE.EducationVest.Domain.Users.Interfaces.InfraData;
using BnE.EducationVest.Infra.Data.Users.Repositories;

namespace BnE.EducationVest.DI
{
    public static class DependencyInjectionBuilder
    {

        public static void InjectApplicationServiceDependencies(this IServiceCollection services) 
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IExamApplicationService, ExamApplicationService>(); 
        }

        public static void InjectInfraServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AwsAuthSettings>(configuration.GetSection("AwsAuth"));
            var awsCognitoSection = configuration.GetSection("AwsAuth");
            var cognitoIdentityProvider = new AmazonCognitoIdentityProviderClient(awsCognitoSection["AcessKey"], awsCognitoSection["SecretKey"], RegionEndpoint.SAEast1);
            var cognitoUserPool = new CognitoUserPool(awsCognitoSection["UserPoolId"], awsCognitoSection["UserPoolClientId"], cognitoIdentityProvider);
            services.AddSingleton<IAmazonCognitoIdentityProvider>(cognitoIdentityProvider);
            services.AddSingleton(cognitoUserPool);
            services.AddScoped<IUserAuthService, UserAuthService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("RedisSettings")["ConnectionString"];
                options.InstanceName = "EducationVest-Cache";
            });

            services.AddScoped<IMailSenderService, MailSenderService>();
        }

        public static void InjectInfraDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EducationVestContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                     x => x.MigrationsAssembly("BnE.EducationVest.API"));
                options.UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
