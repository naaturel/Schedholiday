using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Period;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Repo.UserHoliday
{
    public interface IUserHolidayInfra
    {
        Task<bool> Create(DTOUserHoliday obj);

        Task<IEnumerable<DTOUser>> GetUsersByHoliday(string idHoliday);

        Task<IEnumerable<DTOHoliday>> GetHolidaysByUser(string isUser);

        Task<IEnumerable<DTOPeriod>> GetHolidaysByEpoch(DateTime EpochStart, DateTime EpochEnd);
    }
}
