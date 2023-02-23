using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jb.hifi.core.Interfaces;

namespace jb.hifi.core.Models
{
    public class ApiSettings: IApiSettings
    {
        public string CurrentWeatherDataUrl { get; set; }

        public string CurrentWeatherDataApiKey { get; set; }
    }
}
