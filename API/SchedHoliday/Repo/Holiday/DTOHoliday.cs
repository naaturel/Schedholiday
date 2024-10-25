using System.ComponentModel.DataAnnotations;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Repo.Message;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Repo.Holiday
{
    public class DTOHoliday
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public IEnumerable<DTOUser> Users { get; set; }

        public IEnumerable<DTOActivity>? Activities { get; set; }

        public IEnumerable<DTOMessage>? Messages { get; set; }
    }
}
