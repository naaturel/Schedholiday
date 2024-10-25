using Microsoft.AspNetCore.Identity;
using SchedHoliday.Models;
using SchedHoliday.Repo.User;
using SchedHoliday.Repo;
using SchedHoliday.Services.RepoInterfaces;
using SchedHoliday.ViewModels;
using SchedHoliday.Repo.Meteo;

namespace SchedHoliday.Services
{

    public interface IMeteoService
    {
        Task<string> Get(double lat, double lng);

    }

    public class MeteoService : IMeteoService
    {
        private readonly IMeteoRepo _repo;

        public MeteoService()
        {
            _repo = new MeteoRepo();
        }

        public Task<string> Get(double lat, double lng)
        {
            return _repo.GetMeteo(lat, lng);
        }
    }
}
