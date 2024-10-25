using SchedHoliday.Models;

namespace SchedHoliday.ViewModels
{
    public class MessageGet : IViewModel<Message>
    {

        public string Id { get; set; }

        public string Content { get; set; }

        public long Epoch { get; set; }

        public string Sender { get; set; }
       
        public string HolidayId { get; set; }

        public Message toModel()
        {
            return new Message
            {
                Id = Id,
                Content = Content,
                Date = DateTimeOffset.FromUnixTimeSeconds(Epoch).DateTime,
                SenderName = Sender,
            };
        }
    }

    public class MessagePost : IViewModel<Message>
    {
        public string Content { get; set; }

        public long Epoch { get; set; }

        public string Sender { get; set; }

        public string HolidayId { get; set; }

        public Message toModel()
        {
            return new Message
            {
                Content = Content,
                Date = DateTimeOffset.FromUnixTimeSeconds(Epoch).DateTime,
                SenderId = Sender,
                HolidayId = HolidayId
            };
        }
    }
}
