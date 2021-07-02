using Amazon.CognitoIdentityProvider.Model;
using BnE.EducationVest.Domain;
using BnE.EducationVest.Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnE.EducationVest.API.Middlewares
{
    public class SpecializedExceptionsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public SpecializedExceptionsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotAuthorizedException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new ErrorResponseModel(ErrorConstants.WRONG_PASSWORD));
            }
            catch(UsernameExistsException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new ErrorResponseModel(ErrorConstants.USER_ALREADY_EXISTS));
            }
        }
    }
}
