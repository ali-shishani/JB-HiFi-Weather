using AutoMapper;
using jb.hifi.core.Interfaces;
using jb.hifi.core.Models;
using jb.hifi.core.Models.Input;
using jb.hifi.core.Models.Output;
using jb.hifi.core.Models.Request;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace jb.hifi.service.Services
{
    public class CurrentWeatherDataService : ServiceBase, ICurrentWeatherDataService
    {

        private readonly IMapper _mapper;
        private readonly IOpenWeatherClient _openWeatherClient;

        public CurrentWeatherDataService(ILogger<CurrentWeatherDataService> logger, IOptions<ApiSettings> appSettings, IMapper mapper, IOpenWeatherClient openWeatherClient)
            : base(logger, appSettings)
        {
            _mapper = mapper;
            _openWeatherClient = openWeatherClient;
        }

        public async Task<CurrentWeatherDataOutput> GetCurrentWeatherData(CurrentWeatherDataInput currentWeatherDataRequest)
        {
            var openWeatherDataRequest = new OpenWeatherDataRequest()
            {
                City= currentWeatherDataRequest.City,
                Country= currentWeatherDataRequest.Country,
                CancellationToken = currentWeatherDataRequest.CancellationToken
            };

            var response = await _openWeatherClient.GetCurrentWeatherInfoByCityAndCountryNamesAsync(openWeatherDataRequest);
            var result = _mapper.Map<CurrentWeatherDataOutput>(response);

            return result;
        }
    }
}
