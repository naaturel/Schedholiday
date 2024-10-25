using Microsoft.EntityFrameworkCore;
using SchedHoliday.Exceptions;
using SchedHoliday.Repo;
using SchedHoliday.Repo.Message;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Infra
{
    public class MessageInfra : BaseInfra, IMessageInfra
    {

        public MessageInfra(_DbContext context) : base(context){}

        public async Task<bool> Create(DTOMessage obj)
        {
            try
            {
                obj.Id = Guid.NewGuid().ToString("N");
                await _context.AddAsync(obj);
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

        public async Task<IEnumerable<DTOMessage>> Read()
        {
            try
            {
                var data  = await _context.Messages.Include(m => m.Sender).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

        public async Task<IEnumerable<DTOMessage>> ReadByHolidayId(string id)
        {
            try
            {
                return await _context.Messages.Where(a => a.HolidayId == id)
                    .Include(m => m.Sender).OrderBy(m => m.Date).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }
    }
}
