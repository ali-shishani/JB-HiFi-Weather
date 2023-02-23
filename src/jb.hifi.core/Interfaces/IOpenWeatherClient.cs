using jb.hifi.core.Models.Request;
using jb.hifi.core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jb.hifi.core.Interfaces
{
    public interface IOpenWeatherClient
    {
        Task<OpenWeatherDataResponse> GetCurrentWeatherInfoByCityAndCountryNamesAsync(OpenWeatherDataRequest openWeatherDataRequest);
    }
}
