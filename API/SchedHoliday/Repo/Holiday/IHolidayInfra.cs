using SchedHoliday.Models;

namespace SchedHoliday.Repo.Holiday
{
    public interface IHolidayInfra
    {

        Task<string> Create(DTOHoliday obj, string CreatorId);

        Task<bool> Update(DTOHoliday dto);

        Task<bool> Delete(DTOHoliday dto);

        Task<IEnumerable<DTOHoliday>> Read();

        Task<DTOHoliday> ReadById(string id);

    }
}
