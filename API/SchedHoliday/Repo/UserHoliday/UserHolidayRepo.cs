using SchedHoliday.Infra.Mapper;
using SchedHoliday.Models;
using SchedHoliday.Repo.Holiday;
using SchedHoliday.Repo.Period;
using SchedHoliday.Repo.User;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.UserHoliday
{
    public class UserHolidayRepo : IUserHolidayRepo
    {
        private readonly IMapper<Models.UserHoliday, DTOUserHoliday> _mapper;
        private readonly IMapper<Models.User, DTOUser> _mapperUser;
        private readonly IMapper<Models.Holiday, DTOHoliday> _mapperHoliday;
        private readonly IMapper<Models.Period, DTOPeriod> _mapperPeriod;

        private readonly IUserHolidayInfra _infra;

        public UserHolidayRepo(IUserHolidayInfra infra)
        {
            _mapper = new UserHolidayDTOMapper();
            _mapperUser = new UserDTOMapper();
            _mapperHoliday = new HolidayDTOMapper();
            _mapperPeriod = new PeriodDTOMapper();
            _infra = infra;
        }

        public async Task<bool> Create(Models.UserHoliday obj)
        {
            return await _infra.Create(_mapper.From(obj));
        }

        public async Task<IEnumerable<Models.User>> GetUsersByHoliday(string idHoliday)
        {
            var users = await _infra.GetUsersByHoliday(idHoliday);
            return _mapperUser.FromMany(users);
        }

        public async Task<IEnumerable<Models.Holiday>> GetHolidaysByUser(string idHoliday)
        {
            var users = await _infra.GetHolidaysByUser(idHoliday);
            return _mapperHoliday.FromMany(users);
        }

        public async Task<IEnumerable<Models.Period>> GetHolidaysByEpoch(DateTime epochStart, DateTime epochEnd)
        {
            var peroid = await _infra.GetHolidaysByEpoch(epochStart, epochEnd);
            return _mapperPeriod.FromMany(peroid);
        }
    }
}
