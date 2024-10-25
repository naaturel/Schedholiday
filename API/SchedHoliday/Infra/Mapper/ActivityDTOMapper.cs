using SchedHoliday.Models;
using SchedHoliday.Repo.Activity;

namespace SchedHoliday.Infra.Mapper
{
    public class ActivityDTOMapper : IMapper<Activity, DTOActivity>
    {
        public Activity From(DTOActivity src)
        {
            return new Activity
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                EndDate = src.EndDate,
                StartDate = src.StartDate,
                HolidayId = src.HolidayId
            };
        }

        public DTOActivity From(Activity src)
        {
            return new DTOActivity
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                EndDate = src.EndDate,
                StartDate = src.StartDate,
                HolidayId = src.HolidayId,
            };
        }

        public IEnumerable<Activity> FromMany(IEnumerable<DTOActivity> src)
        {
            var Activitys = new List<Activity>();

            foreach (var dtoA in src)
            {
                Activitys.Add(From(dtoA));

            }
            return Activitys;
        }

        public IEnumerable<DTOActivity> FromMany(IEnumerable<Activity> src)
        {
            var Activitys = new List<DTOActivity>();

            foreach (var act in src)
            {
                Activitys.Add(From(act));

            }

            return Activitys;
        }
    }
}
