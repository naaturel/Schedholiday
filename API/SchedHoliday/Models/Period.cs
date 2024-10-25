using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public class Period
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int NumberUser { get; set; }

        public IViewModel<Period> Convert(string verb)
        {

            switch (verb.ToLower())
            {
                case "get":
                    return new PeriodGet
                    {
                        Latitude = Latitude,
                        Longitude = Longitude,
                        NumberUser = NumberUser
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
