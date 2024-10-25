using SchedHoliday.Repo.Holiday;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SchedHoliday.Repo.Activity
{
    public class DTOActivity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string HolidayId { get; set; }

        public DTOHoliday Holiday { get; set; }

    }
}
