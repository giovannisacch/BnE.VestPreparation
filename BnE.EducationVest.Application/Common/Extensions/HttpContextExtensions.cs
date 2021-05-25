using BnE.EducationVest.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Common.Extensions
{
    public static class HttpContextExtensions
    {
        public static UserTokenData GetTokenData(this IHttpContextAccessor httpContextAccessor)
        {
            var tokenString = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

            var jwtEncodedString = tokenString.Substring(7);

            var token = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

            return new UserTokenData() 
            {
                ClientId = token.Claims.First(c => c.Type == "client_id").Value,
                ExpirationTimespan = token.Claims.First(c => c.Type == "exp").Value,
                CognitoId = token.Claims.First(c => c.Type == "sub").Value,
                Scope = token.Claims.First(c => c.Type == "scope").Value,
                CognitoGroups = token.Claims.Where(c => c.Type == "cognito:groups").Select(x => x.Value) 
            };
        }
    }
}
