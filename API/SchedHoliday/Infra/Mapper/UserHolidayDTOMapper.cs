using SchedHoliday.Models;
using SchedHoliday.Repo.UserHoliday;

namespace SchedHoliday.Infra.Mapper
{
    public class UserHolidayDTOMapper : IMapper<UserHoliday, DTOUserHoliday>
    {
        public UserHoliday From(DTOUserHoliday src)
        {
            return new UserHoliday
            {
                IdHoliday = src.IdHoliday,
                IdUser = src.IdUser,
            };
        }

        public DTOUserHoliday From(UserHoliday src)
        {
            return new DTOUserHoliday
            {
                IdHoliday = src.IdHoliday,
                IdUser = src.IdUser,
                
            };
        }

        public IEnumerable<UserHoliday> FromMany(IEnumerable<DTOUserHoliday> src)
        {
            var UsersHolidays = new List<UserHoliday>();

            foreach (var dtoH in src)
            {
                UsersHolidays.Add(From(dtoH));
            }

            return UsersHolidays;
        }

        public IEnumerable<DTOUserHoliday> FromMany(IEnumerable<UserHoliday> src)
        {
            var UsersHolidays = new List<DTOUserHoliday>();

            foreach (var dtoH in src)
            {
                UsersHolidays.Add(From(dtoH));
            }

            return UsersHolidays;
        }
    }
}
