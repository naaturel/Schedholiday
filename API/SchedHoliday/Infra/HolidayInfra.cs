using Humanizer;
using Microsoft.EntityFrameworkCore;
using SchedHoliday.Exceptions;
using SchedHoliday.Repo;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Infra
{
    public class HolidayInfra : BaseInfra, IHolidayInfra
    {
        public HolidayInfra(_DbContext context) : base(context) { }


        private async Task<bool> AddGroupCreator(string holidayId, string CreatorId)
        {
            var holiday = await _context.Holidays
                    .Where(h => h.Id == holidayId)
                    .Include(h => h.Users)
                    .SingleOrDefaultAsync();
            
            var user = await _context.Users.Where(u => u.Id == CreatorId).SingleOrDefaultAsync();

            holiday.Users = holiday.Users.Concat(new[] { user });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> Create(DTOHoliday dto, string CreatorId)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    dto.Id = Guid.NewGuid().ToString("N");
                    await _context.AddAsync(dto);
                    await _context.SaveChangesAsync();

                    var success = await AddGroupCreator(dto.Id, CreatorId);
                    if(!success) dbContextTransaction.Rollback();


                    dbContextTransaction.Commit();
                    return dto.Id;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new DataBaseException(ex.Message);
                }
            }
        }

        public async Task<bool> Delete(DTOHoliday dto)
        {
            try
            {
                _context.Remove(dto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

        public async Task<IEnumerable<DTOHoliday>> Read()
        {
            try
            {
                return await _context.Holidays.ToListAsync(); 
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task<DTOHoliday> ReadById(string id)
        {
            try
            {
                return await _context.Holidays.Where(a => a.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task<bool> Update(DTOHoliday dto)
        {
            try
            {
                _context.Update(dto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }
    }
}
