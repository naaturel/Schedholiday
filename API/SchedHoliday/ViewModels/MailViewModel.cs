using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{ 

    public class MailPost : IViewModel<Mail>
    {
        public string Email { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }

        public Mail toModel()
        {
            return new Mail
            {
                Email = Email,
                Topic = Topic,
                Message = Message
            };
        }
    }
}
