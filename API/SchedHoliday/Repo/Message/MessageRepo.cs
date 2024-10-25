using Microsoft.EntityFrameworkCore;
using SchedHoliday.Exceptions;
using SchedHoliday.Infra;
using SchedHoliday.Infra.Mapper;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.Message
{
    public class MessageRepo : IMessageRepo
    {

        private readonly IMapper<Models.Message, DTOMessage> _mapper;
        private readonly IMessageInfra _infra;

        public MessageRepo(_DbContext context)
        {
            _mapper = new MessageDTOMapper();
            _infra = new MessageInfra(context);
        }

        public async Task<bool> Create(Models.Message obj)
        {
            return await _infra.Create(_mapper.From(obj));
        }

        public async Task<IEnumerable<Models.Message>> Read()
        {

            var msgs = await _infra.Read();
            return _mapper.FromMany(msgs);
        }

        public async Task<IEnumerable<Models.Message>> ReadByHolidayId(string id)
        {

            var msgs = await _infra.ReadByHolidayId(id);
            
            return _mapper.FromMany(msgs);
        }

    }
}
