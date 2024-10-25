using Microsoft.AspNetCore.Identity;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Message;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedHoliday.Repo.User
{
    public class DTOUser : IdentityUser
    {

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool fromOAuth { get; set ; } 

        [NotMapped]
        public string Password { get; set; }

        public IEnumerable<DTOMessage>? Messages { get; set; }

        public IEnumerable<DTOHoliday>? Holidays { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
