using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{

    public class PeriodGet : IViewModel<Period>
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int NumberUser { get; set; }

        public Period toModel()
        {
            return new Period { Latitude = Latitude, Longitude = Longitude, NumberUser = NumberUser };
        }
    }
}
