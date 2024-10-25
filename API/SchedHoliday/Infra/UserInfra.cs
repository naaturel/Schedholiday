using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchedHoliday.Exceptions;
using SchedHoliday.Infra.Mapper;
using SchedHoliday.Repo;
using SchedHoliday.Repo.User;

namespace SchedHoliday.Infra
{
    public class UserInfra : BaseInfra, IUserInfra
    {


        private readonly UserManager<DTOUser> _userManager;
        private readonly IUserStore<DTOUser> _userStore;
        private readonly IUserEmailStore<DTOUser> _emailStore;

        public UserInfra(_DbContext context, UserManager<DTOUser> userManager, IUserStore<DTOUser> userStore) : base(context) 
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<DTOUser>)_userStore;
        }


        public UserInfra(_DbContext context) : base(context){}

        public async Task<bool> Create(DTOUser dto)
        {
            try { 
                dto.Id = dto.Id == null ? Guid.NewGuid().ToString("N"):dto.Id;

                await _userStore.SetUserNameAsync(dto, dto.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(dto, dto.Email, CancellationToken.None);
                await _userManager.CreateAsync(dto, dto.Password);
                return true;

            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

}

        public async Task<bool> Delete(DTOUser obj)
        {
            try
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task<IEnumerable<DTOUser>> Read()
        {
            try
            {
                return await _context.Users.ToListAsync();
                
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

        public async Task<DTOUser> ReadById(string id)
        {
            try
            {
                return await _context.Users.Where(a => a.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

        public async Task<DTOUser> ReadByEmail(string email)
        {
            try
            {
                var res = await _context.Users.Where(a => a.Email == email).SingleOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }

        }

        public async Task<bool> Update(DTOUser dto)
        {
            try
            {
                _context.Update(dto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public Task<bool> AuthenticateByOAuth()
        {
            var BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            return null;
        }
    }

}
