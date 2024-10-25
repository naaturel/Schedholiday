using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Repo.Message
{
    public class DTOMessage
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string SenderId { get; set; } 

        public string HolidayId { get; set; }

        public DTOUser Sender { get; set; }

        public DTOHoliday Holiday { get; set; }
    }
}
