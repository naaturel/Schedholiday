using SchedHoliday.Exceptions;
using SchedHoliday.Infra.Mapper;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Repo;
using Microsoft.EntityFrameworkCore;

namespace SchedHoliday.Infra
{
    public class ActivityInfra : BaseInfra, IActivtyInfra
    {

        public ActivityInfra(_DbContext context) : base(context){}

        public async Task<bool> Create(DTOActivity dto)
        {
            try
            {
                dto.Id = Guid.NewGuid().ToString("N");

                await _context.AddAsync(dto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

            return true;

        }


        public async Task<IEnumerable<DTOActivity>> Read()
        {
            try
            {
                var res = await _context.Activitys.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task<DTOActivity> ReadById(string id)
        {
            try
            {
                var res = await _context.Activitys.Where(a => a.Id == id).SingleOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }


        public async Task<IEnumerable<DTOActivity>> ReadByHolidayId(string id)
        {
            try
            {
                var res = await _context.Activitys.Where(a => a.HolidayId == id).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }


        public async Task<bool> Update(DTOActivity dto)
        {
            try
            {
                _context.Activitys.Update(dto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

            return true;
        }

        public async Task<bool> Delete(DTOActivity dto)
        {
            try
            {
                _context.Remove(dto);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

            return true;
        }


    }
}
