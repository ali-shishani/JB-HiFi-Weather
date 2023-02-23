using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace jb.hifi.core.Models.Response
{
    public class OpenWeatherDataResponse : ResponseBase
    {
        public string Base { get; set; }

        public int Visibility { get; set; }

        [JsonPropertyName("dt")]
        public long Date { get; set; }

        public int Timezone { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Cod { get; set; }

        public List<OpenWeatherDataResponseWeather> Weather { get; set; }

        public OpenWeatherDataResponseMain Main { get; set; }
        
    }
}
