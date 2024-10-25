using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public class User : IModel<User>
    {
        public string? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public IEnumerable<Message>? Messages { get; set; }

        public IEnumerable<Holiday>? Holidays { get; set; }

        public IViewModel<User> Convert(string verb)
        {

            switch (verb.ToLower())
            {
                case "get":
                    return new UserGet
                    {
                        Id = Id,
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email
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
