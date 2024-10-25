using SchedHoliday.Infra.Mapper;
using SchedHoliday.Repo.Activity;
using SchedHoliday.Repo.UserHoliday;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.Holiday
{
    public class HolidayRepo : IHolidayRepo
    {

        private readonly IMapper<Models.Holiday, DTOHoliday> _mapper;
        private readonly IHolidayInfra _holidayInfra;
        private readonly IUserHolidayInfra _userHolidaInfra;


        public HolidayRepo(IHolidayInfra hInfra, IUserHolidayInfra uhInfra)
        {
            _mapper = new HolidayDTOMapper();
            _holidayInfra = hInfra;
            _userHolidaInfra = uhInfra;
        }

        async Task<string> IHolidayRepo.Create(Models.Holiday obj)
        {
            return await _holidayInfra.Create(_mapper.From(obj), obj.CreatorId);
        }

        async Task<bool> IHolidayRepo.Update(Models.Holiday obj)
        {
            return await _holidayInfra.Update(_mapper.From(obj));
        }

        async Task<bool> IHolidayRepo.Delete(Models.Holiday obj)
        {
            return await _holidayInfra.Delete(_mapper.From(obj));
        }

        async Task<IEnumerable<Models.Holiday>> IHolidayRepo.Read()
        {

            var data = await _holidayInfra.Read();
            return _mapper.FromMany(data);
        }

        async Task<Models.Holiday> IHolidayRepo.ReadById(string id)
        {
            var data = await _holidayInfra.ReadById(id);
            return _mapper.From(data);
        }
    }
}