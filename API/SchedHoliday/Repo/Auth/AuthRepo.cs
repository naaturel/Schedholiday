using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchedHoliday.Exceptions;
using SchedHoliday.Infra;
using SchedHoliday.Infra.Mapper;
using SchedHoliday.Models;
using SchedHoliday.Repo.User;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.Auth
{
    public class AuthRepo : IAuthRepo
    {

        private readonly IMapper<Models.User, DTOUser> _userMapper;
        private readonly IMapper<Authentication, DTOAuth> _authMapper;
        private readonly IMapper<OAuth, DTOOAuth> _oauthMapper;

        private readonly IAuthInfra _authInfra;
        private readonly IUserInfra _userInfra;


        public AuthRepo(IAuthInfra authInfra, IUserInfra userInfra)
        {
            _authInfra = authInfra;
            _userInfra = userInfra;

            _userMapper = new UserDTOMapper();
            _authMapper = new AuthDTOMapper();
            _oauthMapper = new OAuthDTOMapper();
        }


        public async Task<Models.User> Authenticate(Authentication auth)
        {
            var user = await _authInfra.Authenticate(_authMapper.From(auth));
            return _userMapper.From(user);
        }

        public async Task<Models.User> AuthenticateByOAuth(OAuth oauth)
        {
            try
            {
                var oauthUser = await _authInfra.ExtractGoogleOAuth(_oauthMapper.From(oauth));

                if (!await checkUserExists(oauthUser))
                {
                    await _userInfra.Create(oauthUser);
                }

                return _userMapper.From(oauthUser);

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> checkUserExists(DTOUser dtoU)
        {
            DTOUser registeredUser = await _userInfra.ReadByEmail(dtoU.Email);
            return registeredUser != null; 
        }
    }
}