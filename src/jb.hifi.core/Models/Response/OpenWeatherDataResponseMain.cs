using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace jb.hifi.core.Models.Response
{
    public class OpenWeatherDataResponseMain
    {
        public decimal Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public decimal FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public decimal MinTemp { get; set; }

        [JsonPropertyName("temp_max")]
        public decimal MaxTemp { get; set; }

        public int pressure { get; set; }

        public int humidity { get; set; }
    }
}
