using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo;
using SchedHoliday.ViewModels;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Services.RepoInterfaces;
using SchedHoliday.Repo.UserHoliday;

namespace SchedHoliday.Services
{

    public interface IHolidayService
    {
        Task<IEnumerable<IViewModel<Holiday>>> Get();
        Task<IViewModel<Holiday>> GetBy(string id);
        Task<string> Post(HolidayPost holiday);
        Task<bool> Put(HolidayPut holiday);
        Task<bool> Delete(HolidayDelete holiday);
    }

    public class HolidayService : IHolidayService
    {
        private IHolidayRepo _repo;

        public HolidayService(IHolidayInfra hinfra, IUserHolidayInfra uhinfra)
        {
            _repo = new HolidayRepo(hinfra, uhinfra);
        }

        public async Task<bool> Delete(HolidayDelete user)
        {
            return await _repo.Delete(user.toModel());
        }

        public async Task<IEnumerable<IViewModel<Holiday>>> Get()
        {
            var vms = new List<IViewModel<Holiday>>();
            
            foreach (var item in await _repo.Read())
            {
                vms.Add(item.Convert("get"));
            }
            return vms;
        }

        public async Task<IViewModel<Holiday>> GetBy(string id)
        {
            var res = await _repo.ReadById(id);
            return res.Convert("get");
        }

        public async Task<string> Post(HolidayPost holiday)
        {
            checkPeriod(holiday.EpochStart, holiday.EpochEnd);
            return await _repo.Create(holiday.toModel());
        }

        public async Task<bool> Put(HolidayPut holiday)
        {
            checkPeriod(holiday.EpochStart, holiday.EpochEnd); 
            return await _repo.Update(holiday.toModel());
        }


        private void checkPeriod(long epochStart, long epochEnd)
        {
            var currentEpoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            if (epochEnd < epochStart) throw new Exception("End date cannot be before start date");
            if (epochEnd < currentEpoch) throw new Exception("End date cannot be before today");
            if (epochStart < currentEpoch) throw new Exception("Start date cannot be before today");
        }


    }
}



