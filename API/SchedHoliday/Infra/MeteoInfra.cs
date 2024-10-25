using SchedHoliday.Repo.Meteo;

namespace SchedHoliday.Infra
{
    public class MeteoInfra : IMeteoInfra
    {
        public async Task<string> GetMeteo(double lat, double lng)
        {
            string response = "";
                using (var httpClient = new HttpClient())
                {
                    string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lng}&appid=47ba8ece3946c2c8aa79e553cf016999";
                    response = await httpClient.GetStringAsync(apiUrl);
                }
               return response;
        }
    }
}
