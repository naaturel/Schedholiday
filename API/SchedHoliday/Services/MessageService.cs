using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo;
using SchedHoliday.ViewModels;
using SchedHoliday.Repo.Message;
using SchedHoliday.Services.RepoInterfaces;
using PusherServer;
using NuGet.Protocol;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Services
{

    public interface IMessageService
    {
        Task<IEnumerable<IViewModel<Message>>> Get();
        Task<IEnumerable<IViewModel<Message>>> GetBy(string id);
        Task<bool> Post(IViewModel<Message> holiday);
        Task StartChat(string holidayId);

    }


    public class MessageService : IMessageService
    {
        private IMessageRepo _msgRepo;
        private IUserRepo _userRepo;
        private PusherOptions options;
        private Pusher pusher;


        public MessageService(_DbContext context)
        {
            _msgRepo = new MessageRepo(context);
            _userRepo = new UserRepo(context);

            options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };
            pusher = new Pusher(
              "1714740",
              "0794d85e3c42a590d8bc",
              "c10a51fe5302b368dc01",
              options);
        }

        public async Task StartChat(string holidayId)
        {
            var result = await pusher.TriggerAsync(
              $"{holidayId}-channel",
              $"{holidayId}-event",
              new { message = "Chat started" });
        }

        public async Task<IEnumerable<IViewModel<Message>>> Get()
        {
            var vms = new List<IViewModel<Message>>();

            foreach (var item in await _msgRepo.Read())
            {
                vms.Add(item.Convert("get"));
            }

            return vms;
        }

        public async Task<IEnumerable<IViewModel<Message>>> GetBy(string id)
        {
            var vms = new List<IViewModel<Message>>();

            foreach (var item in await _msgRepo.ReadByHolidayId(id))
            {
                vms.Add(item.Convert("get"));
            }

            return vms;
        }

        public async Task<bool> Post(IViewModel<Message> msg)
        {
            Message modelMsg = msg.toModel();
            bool success = await _msgRepo.Create(modelMsg);

            if (!success) throw new Exception("An error occured");

            //String senderName = (await _userRepo.ReadById(modelMsg.Id)).FirstName;
            MessageGet msgget = (MessageGet)modelMsg.Convert("get");
            msgget.Sender = "You";

            await pusher.TriggerAsync(
            $"{modelMsg.HolidayId}-channel",
            $"{modelMsg.HolidayId}-event",
            msgget);

            return success;
        }

    }
}
