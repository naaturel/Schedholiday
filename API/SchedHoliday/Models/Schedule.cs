using System.ComponentModel.DataAnnotations;

namespace SchedHoliday.Models
{
    public class Schedule
    {
        [Required]
        [MaxLength(200)]
        public string? Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Nom")]
        public string? Name { get; set; }

        public Holiday? Holidays { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
