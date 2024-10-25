using SchedHoliday.Repo.Message;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IMessageRepo
    {
        Task<bool> Create(Models.Message obj);

        Task<IEnumerable<Models.Message>> Read();

        Task<IEnumerable<Models.Message>> ReadByHolidayId(string id);

    }
}
