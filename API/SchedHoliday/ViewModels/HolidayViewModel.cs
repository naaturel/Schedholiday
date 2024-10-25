using SchedHoliday.Models;
using System.ComponentModel.DataAnnotations;

namespace SchedHoliday.ViewModels
{



    public class HolidayGet : IViewModel<Holiday>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long EpochStart { get; set; }

        public long EpochEnd { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Holiday toModel()
        {
           return new Holiday { 
               Id = Id, 
               Name = Name,
               StartDate = DateTimeOffset.FromUnixTimeSeconds(EpochStart).DateTime,
               EndDate = DateTimeOffset.FromUnixTimeSeconds(EpochEnd).DateTime,
               Latitude = Latitude,
               Longitude = Longitude 
           };
        }
    }

    public class HolidayPost : IViewModel<Holiday>
    {
        public string Name { get; set; }

        public string CreatorId { get; set; }

        public long EpochStart{ get; set; }

        public long EpochEnd { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Holiday toModel()
        {
            return new Holiday
            {
                Name = Name,
                CreatorId = CreatorId,
                StartDate = DateTimeOffset.FromUnixTimeSeconds(EpochStart).DateTime,
                EndDate = DateTimeOffset.FromUnixTimeSeconds(EpochEnd).DateTime,
                Latitude = Latitude,
                Longitude = Longitude
            };
        }
    }

    public class HolidayPut : IViewModel<Holiday>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long EpochStart { get; set; }

        public long EpochEnd { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Holiday toModel()
        {
            return new Holiday
            {
                Id = Id,
                Name = Name,
                StartDate = DateTimeOffset.FromUnixTimeSeconds(EpochStart).DateTime,
                EndDate = DateTimeOffset.FromUnixTimeSeconds(EpochEnd).DateTime,
                Latitude = Latitude,
                Longitude = Longitude

            };
        }
    }

    public class HolidayDelete : IViewModel<Holiday>
    {
        public string Id { get; set; }

        public Holiday toModel()
        {
            return new Holiday { Id = Id };
        }
    }

}
