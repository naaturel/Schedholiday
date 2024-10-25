using Microsoft.AspNetCore.Identity;
using SchedHoliday.Infra.Mapper;
using SchedHoliday.Infra;
using SchedHoliday.Repo.User;
using SchedHoliday.Services.RepoInterfaces;

namespace SchedHoliday.Repo.Meteo
{
    public class MeteoRepo : IMeteoRepo
    {
        private readonly IMeteoInfra _infra;

        public MeteoRepo()
        {
            _infra = new MeteoInfra();
        }
        public async Task<string> GetMeteo(double lat, double lng)
        {
            return await _infra.GetMeteo(lat, lng);
        }
    }
}
