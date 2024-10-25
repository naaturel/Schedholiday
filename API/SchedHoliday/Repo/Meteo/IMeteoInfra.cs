namespace SchedHoliday.Repo.Meteo
{
    public interface IMeteoInfra
    {
        Task<string> GetMeteo(double lat, double lng);
    }
}
