using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.UserHoliday;
using SchedHoliday.Services.RepoInterfaces;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Services
{
    public interface IUserHolidayService
    {
        Task<bool> Post(IViewModel<UserHoliday> userHoliday);

        Task<IEnumerable<IViewModel<User>>> GetUsersByHoliday(string idHoliday);

        Task<IEnumerable<IViewModel<Holiday>>> GetHolidaysByUser(string idHoliday);

        Task<IEnumerable<IViewModel<Period>>> GetHolidaysByEpoch(DateTime epochStart, DateTime epochEnd);

    }


    public class UserHolidayService : IUserHolidayService
    {
        private IUserHolidayRepo _repo;

        public UserHolidayService(IUserHolidayInfra infra)
        {
            _repo = new UserHolidayRepo(infra);
        }

        public async Task<bool> Post(IViewModel<UserHoliday> userHoliday)
        {
            return await _repo.Create(userHoliday.toModel());
        }

        public async Task<IEnumerable<IViewModel<User>>> GetUsersByHoliday(string idHoliday)
        {
            var vms = new List<IViewModel<User>>();

            foreach (var item in await _repo.GetUsersByHoliday(idHoliday))
            {
                vms.Add(item.Convert("get"));
            }
            return vms;
        }

        public async Task<IEnumerable<IViewModel<Holiday>>> GetHolidaysByUser(string idUser)
        {
            var vms = new List<IViewModel<Holiday>>();

            foreach (var item in await _repo.GetHolidaysByUser(idUser))
            {
                vms.Add(item.Convert("get"));
            }
            return vms;
        }

        public async Task<IEnumerable<IViewModel<Period>>> GetHolidaysByEpoch(DateTime epochStart, DateTime epochEnd)
        {
            var vms = new List<IViewModel<Period>>();

            foreach (var item in await _repo.GetHolidaysByEpoch(epochStart, epochEnd))
            {
                vms.Add(item.Convert("get"));
            }
            return vms;
        }
    }
}
