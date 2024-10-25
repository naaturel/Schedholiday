using SchedHoliday.Models;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IUserHolidayRepo
    {
        Task<bool> Create(UserHoliday obj);

        Task<IEnumerable<User>> GetUsersByHoliday(string idHoliday);

        Task<IEnumerable<Holiday>> GetHolidaysByUser(string idHoliday);

        Task<IEnumerable<Period>> GetHolidaysByEpoch(DateTime epochStart, DateTime epochEnd);
    }
}
