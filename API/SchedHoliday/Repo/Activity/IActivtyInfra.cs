using SchedHoliday.Models;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Repo.Activity
{
    public interface IActivtyInfra
    {

        Task<bool> Create(DTOActivity obj);

        Task<bool> Update(DTOActivity obj);

        Task<bool> Delete(DTOActivity obj);

        Task<IEnumerable<DTOActivity>> Read();

        Task<DTOActivity> ReadById(string id);

        Task<IEnumerable<DTOActivity>> ReadByHolidayId(string id);

    }
}
