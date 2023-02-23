using jb.hifi.core.Interfaces;
using jb.hifi.core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace jb.hifi.service.Services
{
    public abstract class ServiceBase
    {
        protected readonly ILogger<CurrentWeatherDataService> _logger;

        protected readonly IOptions<ApiSettings> _appSettings;

        public ServiceBase(ILogger<CurrentWeatherDataService> logger, IOptions<ApiSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }
    }
}
