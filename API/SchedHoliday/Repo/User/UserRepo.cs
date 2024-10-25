using Microsoft.AspNetCore.Identity;
using SchedHoliday.Infra;
using SchedHoliday.Infra.Mapper;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.User
{
    public class UserRepo : IUserRepo
    {

        private readonly IMapper<Models.User, DTOUser> _mapper;

        private readonly IUserInfra _infra;

        public UserRepo(_DbContext context, UserManager<DTOUser> userManager, IUserStore<DTOUser> userStore)
        {
            _mapper = new UserDTOMapper();
            _infra = new UserInfra(context, userManager, userStore);
        }

        public UserRepo(_DbContext context)
        {
            _infra = new UserInfra(context);
            _mapper = new UserDTOMapper();
        }

        public async Task<bool> Create(Models.User obj)
        {
            return await _infra.Create(_mapper.From(obj));
        }

        public async Task<bool> Delete(Models.User obj)
        { 
            return await _infra.Delete(_mapper.From(obj));
        }

        public async Task<IEnumerable<Models.User>> Read()
        {
           return _mapper.FromMany(await _infra.Read());
        }

        

        public async Task<Models.User> ReadById(string id)
        {
            return _mapper.From(await _infra.ReadById(id));
        }

        public async Task<Models.User> ReadByEmail(string email)
        {
            var res = _mapper.From(await _infra.ReadByEmail(email));
            return res;
        }

        public async Task<bool> Update(Models.User obj)
        {
            return await _infra.Update(_mapper.From(obj));
        }
    }     
}
