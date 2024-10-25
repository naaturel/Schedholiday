using SchedHoliday.Repo.User;
using SchedHoliday.Repo;
using SchedHoliday.Repo.UserHoliday;
using SchedHoliday.Exceptions;
using Microsoft.EntityFrameworkCore;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Period;

namespace SchedHoliday.Infra
{
    public class UserHolidayInfra : BaseInfra, IUserHolidayInfra
    {
        public UserHolidayInfra(_DbContext context) : base(context) { }

        public async Task<bool> Create(DTOUserHoliday dto)
        {
            try
            {

                var holiday = await _context.Holidays
                    .Where(h => h.Id == dto.IdHoliday.FirstOrDefault())
                    .Include(h => h.Users)
                    .SingleOrDefaultAsync();

                var user = await _context.Users.Where(u => u.Id == dto.IdUser.FirstOrDefault()).SingleOrDefaultAsync();

                holiday.Users = holiday.Users.Concat(new[] {user});
              
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task<IEnumerable<DTOPeriod>> GetHolidaysByEpoch(DateTime EpochStart, DateTime EpochEnd)
        {
            var holidays = await _context.Holidays.Where(h => h.StartDate <= EpochStart && h.EndDate <= EpochEnd).Include(h => h.Users).ToListAsync();
            List<DTOPeriod> periods = new List<DTOPeriod>();
            foreach (var holiday in holidays) {
                periods.Add(new DTOPeriod { Latitude = holiday.Latitude, Longitude = holiday.Longitude, NumberUser = holiday.Users.Count() });
            }
            return periods;
        }

        public async Task<IEnumerable<DTOHoliday>> GetHolidaysByUser(string idUser)
        {
            var user = await _context.Users.Where(u => u.Id == idUser).Include(u => u.Holidays).FirstOrDefaultAsync();
            return user.Holidays;
        }

        public async Task<IEnumerable<DTOUser>> GetUsersByHoliday(string idHoliday)
        {
            var holidays = await _context.Holidays.Where(h => h.Id == idHoliday).Include(h => h.Users).FirstOrDefaultAsync();
            return holidays.Users;
        }
    }
}