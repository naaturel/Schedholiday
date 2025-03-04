﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchedHoliday.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SchedHoliday.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService; 
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IUserService userService)
        {
            _next = next;
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, token);

            await _next(context);
        }


        private void attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

                // attach user to context on successful jwt validation

                context.Items["User"] = _userService.GetBy(userId);

            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
