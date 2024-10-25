using Microsoft.AspNetCore.Identity;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Repo
{
    public static class DataInitializer
    {

        public static async Task Seed(UserManager<DTOUser> userManager)
        {
            /*if (userManager.Users.Count() != 0) return;

            for (int i = 0; i < 5; i++)
            {

                
                var firstName = new Bogus.Person().FirstName;
                var lastName = new Bogus.Person().LastName;

                var email = $"{firstName}.{lastName}@gmail.be";
                var driver = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email

                };

                var result = userManager.CreateAsync(driver, "Mdp_123").Result;

            }*/
        }
    }
}
