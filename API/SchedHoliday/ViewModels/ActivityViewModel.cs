using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{

    public class ActivityGet : IViewModel<Activity>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public long EpochStart { get; set; }

        public long EpochEnd { get; set; }

        public string HolidayId { get; set; }

        public Activity toModel()
        {
            return new Activity
            {
                Name = Name,
                Description = Description,
                StartDate = DateTimeOffset.FromUnixTimeSeconds(EpochStart).DateTime,
                EndDate = DateTimeOffset.FromUnixTimeSeconds(EpochEnd).DateTime,
                HolidayId = HolidayId
            };
        }
    }

    public class ActivityPost : IViewModel<Activity>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long EpochStart { get; set; }

        public long EpochEnd { get; set; }

        public string HolidayId { get;set ; }

        public Activity toModel()
        {
            return new Activity
            {
                Name = Name,
                Description = Description,
                StartDate = DateTimeOffset.FromUnixTimeSeconds(EpochStart).DateTime,
                EndDate = DateTimeOffset.FromUnixTimeSeconds(EpochEnd).DateTime,
                HolidayId = HolidayId
            };
        }
    }

    public class ActivityPut : IViewModel<Activity>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long EpochStart { get; set; }

        public long EpochEnd { get; set; }

        public Activity toModel()
        {
            return new Activity
            {
                Id = Id,
                Name = Name,
                Description = Description,
                StartDate = DateTimeOffset.FromUnixTimeSeconds(EpochStart).DateTime,
                EndDate = DateTimeOffset.FromUnixTimeSeconds(EpochEnd).DateTime,
            };
        }
    }

    public class ActivityDelete : IViewModel<Activity>
    {
        public string Id { get; set; }

        public Activity toModel()
        {
            return new Activity { Id = Id };
        }
    }
}

