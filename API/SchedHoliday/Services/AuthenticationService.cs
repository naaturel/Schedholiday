using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using SchedHoliday.Infra;
using SchedHoliday.Models;
using SchedHoliday.Repo;
using SchedHoliday.Repo.Auth;
using SchedHoliday.Repo.User;
using SchedHoliday.Services.RepoInterfaces;
using SchedHoliday.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchedHoliday.Services
{

    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest model);

        Task<AuthenticationResponse> AuthenticateByOAuth(OAuthRequest model);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepo _repo;

        public AuthenticationService(IAuthInfra authInfra, IUserInfra userInfra, IConfiguration config) {

            _configuration = config;
            _repo = new AuthRepo(authInfra, userInfra);

        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest viewModel)
        {

            var user = await _repo.Authenticate(viewModel.toModel());
            
            var token = generateToken(user);

            return new AuthenticationResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
        }

        public async Task<AuthenticationResponse> AuthenticateByOAuth(OAuthRequest viewModel)
        {
            var user = await _repo.AuthenticateByOAuth(viewModel.toModel());
            var token = generateToken(user);
            return new AuthenticationResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };

        }

        private string generateToken(User user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.FirstName!),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                     }),
                Expires = DateTime.UtcNow.AddMinutes(360),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;

        }
    }
}
