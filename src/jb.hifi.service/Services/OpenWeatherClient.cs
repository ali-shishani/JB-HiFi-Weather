using jb.hifi.core.Interfaces;
using jb.hifi.core.Models;
using jb.hifi.core.Models.Request;
using jb.hifi.core.Models.Response;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace jb.hifi.service.Services
{
    public class OpenWeatherClient : ServiceBase, IOpenWeatherClient
    {
        private readonly string _url;

        private readonly string _key;

        public OpenWeatherClient(ILogger<CurrentWeatherDataService> logger, IOptions<ApiSettings> appSettings)
            : base(logger, appSettings)
        {
            _url = appSettings.Value.CurrentWeatherDataUrl;
            _key = appSettings.Value.CurrentWeatherDataApiKey;
        }

        public async Task<OpenWeatherDataResponse> GetCurrentWeatherInfoByCityAndCountryNamesAsync(OpenWeatherDataRequest openWeatherDataRequest)
        {
            try
            {
                var url = _url + "?q=" + $"{openWeatherDataRequest.City},{openWeatherDataRequest.Country}" + "&appid=" + _key;
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(url)
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

                var weatherData = await httpClient.GetFromJsonAsync<OpenWeatherDataResponse>(url, openWeatherDataRequest.CancellationToken);

                if (weatherData != null)
                {
                    weatherData.Success = true;
                    return weatherData;
                }
                else
                {
                    var logMessage = "OpenWeatherClient.GetCurrentWeatherInfoByCityAndCountryNamesAsync()" + " | Message: Could n";
                    _logger.LogError(logMessage);

                    return new OpenWeatherDataResponse()
                    {
                        Success = false,
                        Errors = new List<ResponseError>()
                        {
                            new ResponseError()
                            {
                                Code = HttpStatusCode.InternalServerError.ToString(),
                                Message = logMessage
                            }
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                var logMessage = "Message:" + ex.Message + " | StackTrace:" + ex.StackTrace;
                _logger.LogError(logMessage);

                return new OpenWeatherDataResponse()
                {
                    Success = false,
                    Errors = new List<ResponseError>()
                    {
                        new ResponseError()
                        {
                            Code = HttpStatusCode.InternalServerError.ToString(),
                            Message = logMessage
                        }
                    }
                };
            }

        }
    }
}
