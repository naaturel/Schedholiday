using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{
    public class UserGet : IViewModel<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public User toModel()
        {
            return new User { 
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };
        }
    }

    public class UserPost : IViewModel<User>
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User toModel()
        {
            return new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
        }
    }

    public class UserPut : IViewModel<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User toModel()
        {
            return new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
        }

    }

    public class UserDelete : IViewModel<User>
    {
        public string Id { get; set; }

        public User toModel()
        {
            return new User
            {
                Id = Id,
            };
        }
    }
}
