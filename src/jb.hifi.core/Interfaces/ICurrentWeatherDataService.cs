using jb.hifi.core.Models.Input;
using jb.hifi.core.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jb.hifi.core.Interfaces
{
    public interface ICurrentWeatherDataService
    {
        Task<CurrentWeatherDataOutput> GetCurrentWeatherData(CurrentWeatherDataInput openWeatherDataRequest);
    }
}
