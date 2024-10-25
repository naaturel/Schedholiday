using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public class UserHoliday : IModel<UserHoliday>
    {

        public IEnumerable<string> IdHoliday { get; set; }
        public IEnumerable<string> IdUser { get; set; }

        public IViewModel<UserHoliday> Convert(string verb)
        {
            switch (verb.ToLower())
            {
                case "get":
                    return new UserHolidayPost
                    {
                        IdHoliday = IdHoliday,
                        IdUser = IdUser,
                    };
                case "post":
                    break;
                case "put":
                    break;
                case "delete":
                    break;
            }

            return null;
        }
    }
}
