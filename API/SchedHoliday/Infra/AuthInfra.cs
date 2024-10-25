using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchedHoliday.Exceptions;
using SchedHoliday.Models;
using SchedHoliday.Repo;
using SchedHoliday.Repo.Auth;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Infra
{
    public class AuthInfra : BaseInfra, IAuthInfra
    {
        private readonly SignInManager<DTOUser> _signInManager;
        private readonly UserManager<DTOUser> _userManager;
        private readonly IUserStore<DTOUser> _userStore;
        private readonly IUserEmailStore<DTOUser> _emailStore;

        public AuthInfra(_DbContext context, UserManager<DTOUser> userManager, 
            IUserStore<DTOUser> userStore, SignInManager<DTOUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<DTOUser>)_userStore;
            _signInManager = signInManager;
        }

        public async Task<DTOUser> Authenticate(DTOAuth dto)
        {
            try
            {
                var res = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, true);

                if (res.IsLockedOut) throw new DataBaseException("Your account is locked out for 5 minutes after failing 5 times.");
                if (!res.Succeeded) throw new DataBaseException("Email or password incorrect");

                var u = await _context.Users.Where(u => u.UserName.Equals(dto.Email)).SingleOrDefaultAsync();

                return u;

            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task<DTOUser> ExtractGoogleOAuth(DTOOAuth oauth)
        {
            var userData = await GoogleJsonWebSignature.ValidateAsync(oauth.Token);

            return new DTOUser
            {
                Id = userData.Subject,
                FirstName = userData.GivenName,
                LastName = userData.FamilyName,
                Email = userData.Email,
                fromOAuth = true,
                Password = $"OAuth_{Guid.NewGuid()}",
            };
        }
    }
}