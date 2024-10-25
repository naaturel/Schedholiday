using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public class Activity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string HolidayId { get; set; }

        public IViewModel<Activity> Convert(string verb)
        {

            switch (verb.ToLower())
            {
                case "get":
                    return new ActivityGet
                    {
                        Name = Name,
                        Description = Description,
                        EpochStart = (int)((StartDate == null ? DateTime.UtcNow : StartDate) - new DateTime(1970, 1, 1)).TotalSeconds,
                        EpochEnd = (int)((EndDate == null ? DateTime.UtcNow : EndDate) - new DateTime(1970, 1, 1)).TotalSeconds,
                    };
                case "post":
                    break;
                case "put":
                    break;
                case "delete":
                    break;
            }

            return null;

        }

    }
}
