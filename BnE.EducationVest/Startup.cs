using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using BnE.EducationVest.DI;
using BnE.EducationVest.API.Middlewares;
using BnE.EducationVest.Domain.Common.SettingsModels;
using System.IO;
using System;
using Newtonsoft.Json.Converters;
using BnE.EducationVest.Infra.Service.Common.Models;

namespace BnE.EducationVest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<AWSAuth>(Configuration.GetSection("AWSAuth"));
            services.InjectApplicationServiceDependencies();
            services.InjectInfraServiceDependencies(Configuration);
            services.InjectInfraDataDependencies(Configuration);
            services.InjectDomainServices();

            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsDefault", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };
                    options.Authority = Configuration.GetSection("AWSAuth:CognitoAuthority").Value;
                    options.RequireHttpsMetadata = false;
                });
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                                        {
                                            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                                            options.SerializerSettings.Converters.Add(new StringEnumConverter());
                                         }
                                        );
            services.AddSwaggerGenNewtonsoftSupport();

            #region SWAGGER GEN
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BnE.EducationVest", Version = "v1" });
                Console.WriteLine("Base DIrectory");
                Console.WriteLine();
                var XMLPath = AppDomain.CurrentDomain.BaseDirectory + "BnE.EducationVest.API" + ".xml";
                if (File.Exists(XMLPath))
                {
                    c.IncludeXmlComments(XMLPath);
                }
                else
                    c.IncludeXmlComments(Path.GetFullPath("../BnE.EducationVest/BnE.EducationVest.API.xml"));
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            Console.Write(env.EnvironmentName);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  
            }
            app.UseCors("CorsDefault");
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BnE.EducationVest v1"));

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<SpecializedExceptionsHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
