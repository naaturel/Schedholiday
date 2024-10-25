using SchedHoliday.Models;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IHolidayRepo
    {
        Task<string> Create(Holiday obj);

        Task<bool> Update(Holiday obj);

        Task<bool> Delete(Holiday obj);

        Task<IEnumerable<Models.Holiday>> Read();

        Task<Holiday> ReadById(string id);
    }
}
