using SchedHoliday.Models;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IActivityRepo
    {
        Task<bool> Create(Activity obj);

        Task<bool> Update(Activity obj);

        Task<bool> Delete(Activity obj);

        Task<IEnumerable<Activity>> Read();

        Task<Activity> ReadById(string id);
        Task<IEnumerable<Activity>> ReadByHolidayId(string id);

    }
}
