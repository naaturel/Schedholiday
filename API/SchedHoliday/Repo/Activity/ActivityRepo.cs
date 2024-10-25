using SchedHoliday.Infra.Mapper;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.Activity
{
    public class ActivityRepo : IActivityRepo
    {

        private readonly IMapper<Models.Activity, DTOActivity> _mapper;
        private readonly IActivtyInfra _infra;

        public ActivityRepo(IActivtyInfra infra) {
            _mapper = new ActivityDTOMapper();
            _infra = infra;
        }

        public async Task<bool> Create(Models.Activity obj)
        {
            return await _infra.Create(_mapper.From(obj));
        }

        public async Task<bool> Delete(Models.Activity obj)
        {
            return await _infra.Delete(_mapper.From(obj));
        }

        public async Task<IEnumerable<Models.Activity>> Read()
        {
            return _mapper.FromMany(await _infra.Read());
        }

        public async Task<IEnumerable<Models.Activity>> ReadByHolidayId(string id)
        {
            return _mapper.FromMany(await _infra.ReadByHolidayId(id));
        }

        public async Task<Models.Activity> ReadById(string id)
        {
            return  _mapper.From(await _infra.ReadById(id));
        }

        public async Task<bool> Update(Models.Activity obj)
        {
            return await _infra.Update(_mapper.From(obj));
        }
    }
}