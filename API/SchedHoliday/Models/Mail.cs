using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public class Mail : IModel<Mail>
    {
        public string Email { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }

        public IViewModel<Mail> Convert(string verb)
        {
            return null;
        }
    }
}
