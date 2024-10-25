using SchedHoliday.Repo.User;

namespace SchedHoliday.Repo.Auth
{
    public interface IAuthInfra
    {
        Task<DTOUser> Authenticate(DTOAuth auth);

        Task<DTOUser> ExtractGoogleOAuth(DTOOAuth oauth);
    }
}
