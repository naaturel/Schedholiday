using SchedHoliday.Models;

namespace SchedHoliday.Services.RepoInterfaces
{
    public interface IMeteoRepo
    {
        Task<string> GetMeteo(double lat, double lng);
    }
}
