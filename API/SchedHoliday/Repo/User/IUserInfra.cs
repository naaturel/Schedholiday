namespace SchedHoliday.Repo.User
{
    public interface IUserInfra
    {

        Task<bool> Create(DTOUser obj);

        Task<bool> Update(DTOUser obj);

        Task<bool> Delete(DTOUser obj);

        Task<IEnumerable<DTOUser>> Read();

        Task<DTOUser> ReadById(string id);

        Task<DTOUser> ReadByEmail(string email);

    }
}
