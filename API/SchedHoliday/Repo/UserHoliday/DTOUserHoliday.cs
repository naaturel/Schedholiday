using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Repo.UserHoliday
{
    public class DTOUserHoliday
    {
        public IEnumerable<string> IdHoliday {get; set;}
        public IEnumerable<string> IdUser { get; set; }
        public DTOHoliday DTOHoliday {get; set; }
        public DTOUser DTOUser { get; set; }

    }
}
