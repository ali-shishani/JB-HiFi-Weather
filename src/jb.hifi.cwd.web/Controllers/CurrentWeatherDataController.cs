using jb.hifi.core.Interfaces;
using jb.hifi.core.Models.Input;
using jb.hifi.core.Models.Output;
using Microsoft.AspNetCore.Mvc;

namespace jb.hifi.cwd.react.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentWeatherDataController : ControllerBase
    {
        private readonly ILogger<CurrentWeatherDataController> _logger;

        private readonly ICurrentWeatherDataService _currentWeatherDataService;

        public CurrentWeatherDataController(ILogger<CurrentWeatherDataController> logger, ICurrentWeatherDataService currentWeatherDataService)
        {
            _logger = logger;
            _currentWeatherDataService = currentWeatherDataService;
        }

        [HttpGet]
        public async Task<CurrentWeatherDataOutput> Get(string city, string country)
        {
            var currentWeatherDataInput = new CurrentWeatherDataInput()
            {
                City= city,
                Country= country
            };

            return await _currentWeatherDataService.GetCurrentWeatherData(currentWeatherDataInput);
        }
    }
}