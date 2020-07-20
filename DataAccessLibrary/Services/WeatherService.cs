using System.Threading.Tasks;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.Weather;
using Newtonsoft.Json;

namespace DataAccessLibrary.Services
{
    public class WeatherService
    {
        public async Task<dynamic> GetWeather(double lat, double lon)
        {
            string queryString = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=9515be1524e18bb3c67b4d51d3b6addf";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                CoreWeather weather = new CoreWeather();
                weather = JsonConvert.DeserializeObject<CoreWeather>(results);

                return weather;
            }
            
            return null;
        }
    }
}