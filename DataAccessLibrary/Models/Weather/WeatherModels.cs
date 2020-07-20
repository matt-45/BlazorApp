using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataAccessLibrary.Models.Weather
{
    public class Weather {
        [JsonProperty("main")]
        public string Title { get; set; } 
        public string Description { get; set; } 
        [JsonProperty("icon")]
        public string IconKey { get; set; }

        public string IconPath
        {
            get
            {
                return $"http://openweathermap.org/img/wn/{IconKey}@2x.png";
            }
        }
    }

    public class Main {
        [JsonProperty("temp")]
        public double TempInKelvin { get; set; }
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public double MinTemp { get; set; }
        [JsonProperty("temp_max")]
        public double MaxTemp { get; set; } 
        public int Pressure { get; set; } 
        public int Humidity { get; set; }

        public double Temperature
        {
            get
            {
                return Math.Round((TempInKelvin - 273.15) * 9 / 5 + 32, 1);
            }
        }
    }

    public class Wind {
        public double Speed { get; set; } 
        public double Deg { get; set; }
    }
    
    public class CoreWeather {
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; } 
        public Wind Wind { get; set; }
        [JsonProperty("Name")]
        public string City { get; set; }
    }
}