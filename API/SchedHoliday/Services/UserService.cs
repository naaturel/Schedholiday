using Microsoft.AspNetCore.Identity;
using SchedHoliday.Models;
using SchedHoliday.Repo;
using SchedHoliday.Repo.User;
using SchedHoliday.Services.RepoInterfaces;
using SchedHoliday.ViewModels;

namespace SchedHoliday.Services
{
    public interface IUserService
    {
        Task<IEnumerable<IViewModel<User>>> Get();
        
        Task<IViewModel<User>> GetBy(string id);
        Task<IViewModel<User>> GetByEmail(string email);

        Task<bool> Post(IViewModel<User> user);
        Task<bool> Put(IViewModel<User> user);
        Task<bool> Delete(IViewModel<User> user);
    }

    public class UserService : IUserService
    {

        private readonly IUserRepo _repo;

        public UserService(_DbContext context, UserManager<DTOUser> userManager, IUserStore<DTOUser> userStore)
        {
            _repo = new UserRepo(context, userManager, userStore);
        }

        public async Task<IEnumerable<IViewModel<User>>> Get()
        {

            var vms = new List<IViewModel<User>>();
            
            foreach (var item in await _repo.Read())
            {
                vms.Add(item.Convert("get"));
            }

            return vms;

        }

        public async Task<IViewModel<User>> GetBy(string id)
        {
            var res = await _repo.ReadById(id);
            return res.Convert("get");
        }

        public async Task<IViewModel<User>> GetByEmail(string email)
        {
            var res = await _repo.ReadByEmail(email);
            return res.Convert("get");
        }

        public async Task<bool> Post(IViewModel<User> user)
        {
            return await _repo.Create(user.toModel());
        }

        public async Task<bool> Put(IViewModel<User> user)
        {
            return await _repo.Update(user.toModel());
        }

        public async Task<bool> Delete(IViewModel<User> user)
        {
            return await _repo.Delete(user.toModel());
        }

       
    }
}
