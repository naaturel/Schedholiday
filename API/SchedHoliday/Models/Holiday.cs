using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{

    public class Holiday : IModel<Holiday>
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public string CreatorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public IViewModel<Holiday> Convert(string verb)
        {
            switch (verb.ToLower())
            {
                case "get":
                    return new HolidayGet
                    {
                        Id = Id,
                        Name = Name,
                        EpochStart = (int)(StartDate - new DateTime(1970, 1, 1)).TotalSeconds,
                        EpochEnd = (int)(EndDate - new DateTime(1970, 1, 1)).TotalSeconds, 
                        Longitude = Longitude,
                        Latitude = Latitude,
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
