using SchedHoliday.Models;
using System.Threading.Tasks;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IUserRepo
    {

        Task<bool> Create(User obj);

        Task<bool> Update(User obj);

        Task<bool> Delete(User obj);

        Task<IEnumerable<User>> Read();

        Task<User> ReadById(string id);

        Task<User> ReadByEmail(string email);



    }
}
