using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Period;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Infra.Mapper
{
    public class PeriodDTOMapper : IMapper<Period, DTOPeriod>
    {
        public Period? From(DTOPeriod src)
        {
            if (src == null) return null;

            return new Period
            {
                Latitude = src.Latitude,
                Longitude = src.Longitude,
                NumberUser = src.NumberUser,
            };
        }

        public DTOPeriod From(Period src)
        {
            return new DTOPeriod
            {
                
            };
        }

        public IEnumerable<Period> FromMany(IEnumerable<DTOPeriod> src)
        {
            var periods = new List<Period>();

            foreach (var dto in src)
            {
                periods.Add(From(dto));

            }

            return periods;

        }

        public IEnumerable<DTOPeriod> FromMany(IEnumerable<Period> src)
        {
            var users = new List<DTOPeriod>();

            foreach (var dtoU in src)
            {
                users.Add(From(dtoU));

            }

            return users;
        }
    }
}
