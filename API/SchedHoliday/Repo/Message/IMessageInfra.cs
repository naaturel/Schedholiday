namespace SchedHoliday.Repo.Message
{
    public interface IMessageInfra
    {

        Task<bool> Create(DTOMessage obj);

        Task<IEnumerable<DTOMessage>> Read();

        Task<IEnumerable<DTOMessage>> ReadByHolidayId(string id);


    }
}
