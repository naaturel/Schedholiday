using SchedHoliday.Models;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IAuthRepo
    {
        Task<User> Authenticate(Authentication model);

        Task<User> AuthenticateByOAuth(OAuth model);

    }
}
