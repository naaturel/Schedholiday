using SchedHoliday.Exceptions;
using SchedHoliday.Infra;
using SchedHoliday.Models;

namespace SchedHoliday.Repo
{

    public class BaseInfra
    {

        protected _DbContext _context;


        public BaseInfra(_DbContext context)
        {
            _context = context;
        }
    }
}
