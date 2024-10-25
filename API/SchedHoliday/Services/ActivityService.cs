using SchedHoliday.Models;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Services.RepoInterfaces;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Services
{

    public interface IActivityService
    {
        Task<IEnumerable<IViewModel<Activity>>> Get();
        Task<IViewModel<Activity>> GetBy(string id);
        Task<IEnumerable<IViewModel<Activity>>> GetByHoliday(string id);
        Task<bool> Post(ActivityPost Activity);
        Task<bool> Put(IViewModel<Activity> Activity);
        Task<bool> Delete(IViewModel<Activity> Activity);
    }

    public class ActivityService : IActivityService
    {

        private readonly IActivityRepo _ActivityRepo;

        public ActivityService(IActivtyInfra infra)
        {
            _ActivityRepo = new ActivityRepo(infra);
        }

        public async Task<IEnumerable<IViewModel<Activity>>> Get()
        {

            var vms = new List<IViewModel<Activity>>();

            foreach (var item in await _ActivityRepo.Read())
            {
                vms.Add(item.Convert("get"));
            }

            return vms;
        }

        public async Task<IViewModel<Activity>> GetBy(string id)
        {
            var data = await _ActivityRepo.ReadById(id);
            return data.Convert("get");
        }

        public async Task<IEnumerable<IViewModel<Activity>>> GetByHoliday(string id)
        {
            var vms = new List<IViewModel<Activity>>();

            foreach (var item in await _ActivityRepo.ReadByHolidayId(id))
            {
                vms.Add(item.Convert("get"));
            }

            return vms;
        }

        public async Task<bool> Post(ActivityPost activity)
        {
            checkPeriod(activity.EpochStart, activity.EpochEnd);
            return await _ActivityRepo.Create(activity.toModel());
        }

        public async Task<bool> Put(ActivityPut activity)
        {
            checkPeriod(activity.EpochStart, activity.EpochEnd);
            return await _ActivityRepo.Update(activity.toModel());
        }

        public async Task<bool> Delete(ActivityDelete Activity)
        {
            return await _ActivityRepo.Delete(Activity.toModel());
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
