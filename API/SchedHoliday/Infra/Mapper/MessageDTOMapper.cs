using SchedHoliday.Models;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Repo.Message;

namespace SchedHoliday.Infra.Mapper
{
    public class MessageDTOMapper : IMapper<Message, DTOMessage>
    {
        public Message From(DTOMessage src)
        {
            return new Message
            {
                Id = src.Id,
                Content = src.Content,
                Date = src.Date,
                SenderName = src.Sender.FirstName,
                SenderId = src.SenderId,
                HolidayId = src.HolidayId,
            };
        }

        public DTOMessage From(Message src)
        {
            return new DTOMessage
            {
                Id = src.Id,
                Content = src.Content,
                Date = src.Date,
                SenderId = src.SenderId,
                HolidayId = src.HolidayId,
            };
        }

        public IEnumerable<Message> FromMany(IEnumerable<DTOMessage> src)
        {
            var Messages = new List<Message>();

            foreach (var dtoM in src)
            {
                Messages.Add(From(dtoM));
            }

            return Messages;
        }

        public IEnumerable<DTOMessage> FromMany(IEnumerable<Message> src)
        {
            var Messages = new List<DTOMessage>();

            foreach (var mess in src)
            {
                Messages.Add(From(mess));

            }

            return Messages;
        }
    }
}
