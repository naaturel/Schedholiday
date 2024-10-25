using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;

namespace SchedHoliday.Infra.Mapper
{
    public class HolidayDTOMapper : IMapper<Holiday, DTOHoliday>
    {
        public Holiday From(DTOHoliday src)
        {
            return new Holiday
            {
                Id = src.Id,
                Name = src.Name,
                StartDate = src.StartDate,
                EndDate = src.EndDate,
                Longitude = src.Longitude,
                Latitude = src.Latitude
            };
        }

        public DTOHoliday From(Holiday src)
        {
            return new DTOHoliday
            {
                Id = src.Id,
                Name = src.Name,
                StartDate = src.StartDate,
                EndDate = src.EndDate,
                Longitude = src.Longitude,
                Latitude = src.Latitude
            };
        }

        public IEnumerable<Holiday> FromMany(IEnumerable<DTOHoliday> src)
        {
            var Holidays = new List<Holiday>();

            foreach (var dtoH in src)
            {
                Holidays.Add(From(dtoH));
            }

            return Holidays;

        }

        public IEnumerable<DTOHoliday> FromMany(IEnumerable<Holiday> src)
        {
            var Holidays = new List<DTOHoliday>();

            foreach (var dtoH in src)
            {
                Holidays.Add(From(dtoH));
            }

            return Holidays;
        }


    }
}
