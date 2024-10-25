using Bogus.DataSets;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.User;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public class Message
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string SenderName { get; set; }

        public string SenderId { get; set; }

        public string HolidayId { get; set; }

        public IViewModel<Message> Convert(string verb)
        {

            switch (verb.ToLower())
            {
                case "get":
                    return new MessageGet
                    {
                        Id = Id,
                        Content = Content,
                        Epoch = (int)(Date - new DateTime(1970, 1, 1)).TotalSeconds,
                        Sender = SenderName,
                        HolidayId = HolidayId
                    };
                case "post":
                    break;
                case "put":
                    break;
                case "delete":
                    break;
            }

            return null;

        }
    }
}
