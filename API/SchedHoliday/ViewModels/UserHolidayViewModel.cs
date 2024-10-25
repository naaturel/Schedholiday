using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{
    public class UserHolidayPost : IViewModel<UserHoliday>
    {
        public IEnumerable<string> IdHoliday { get; set; }

        public IEnumerable<string> IdUser { get; set; }

        public UserHoliday toModel()
        {
            return new UserHoliday { IdHoliday = IdHoliday, IdUser = IdUser };
        }
    }
}
