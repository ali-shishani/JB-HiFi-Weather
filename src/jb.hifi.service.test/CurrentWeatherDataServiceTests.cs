using AutoMapper;
using jb.hifi.core.Interfaces;
using jb.hifi.core.Models;
using jb.hifi.core.Models.Input;
using jb.hifi.core.Models.Request;
using jb.hifi.core.Models.Response;
using jb.hifi.service.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace jb.hifi.service.test.Tests
{
    [TestFixture]
    public class CurrentWeatherDataServiceTests
    {
        // mocks
        Mock<ILogger<CurrentWeatherDataService>> mockLogger;
        Mock<IOptions<ApiSettings>> mockAppSettings;
        IMapper mapper;
        Mock<IOpenWeatherClient> mockOpenWeatherClient;
        Mock<IOpenWeatherClient> mockOpenWeatherClientWithError;

        // service
        CurrentWeatherDataService currentWeatherDataService;

        [SetUp]
        public void Setup()
        {
            mockLogger = new Mock<ILogger<CurrentWeatherDataService>>(MockBehavior.Loose);
            mockAppSettings = new Mock<IOptions<ApiSettings>>(MockBehavior.Loose);

            var myProfile = new CategoryProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            var openWeatherDataRequest = new OpenWeatherDataRequest()
            {
                City = "Melbourne",
                Country = "AU",
            };

            mockOpenWeatherClient = new Mock<IOpenWeatherClient>(MockBehavior.Loose);
            var openWeatherDataResponse = new OpenWeatherDataResponse()
            {
                Weather = new List<OpenWeatherDataResponseWeather>()
                {
                    new OpenWeatherDataResponseWeather()
                    {
                        Description = "sunny"
                    },
                },
                Success = true,
                Errors = new List<ResponseError>(),
            };

            mockOpenWeatherClient
                .Setup( p => p.GetCurrentWeatherInfoByCityAndCountryNamesAsync(It.IsAny<OpenWeatherDataRequest>()))
                .Returns(Task.FromResult(openWeatherDataResponse));

            mockOpenWeatherClientWithError = new Mock<IOpenWeatherClient>(MockBehavior.Loose);
            var openWeatherDataResponseWithError = new OpenWeatherDataResponse()
            {
                Success = false,
                Errors = new List<ResponseError>()
                {
                    new ResponseError()
                    {
                        Code= "500",
                        Message = "Internal Server Error"
                    }
                }
            };

            mockOpenWeatherClientWithError
                .Setup(p => p.GetCurrentWeatherInfoByCityAndCountryNamesAsync(It.IsAny<OpenWeatherDataRequest>()))
                .Returns(Task.FromResult(openWeatherDataResponseWithError));
        }

        [Test]
        public async Task CurrentWeatherDataService_Can_Handle_Successful_OpenWeather_Response()
        {
            var input = new CurrentWeatherDataInput()
            {
                City = "Melbourne",
                Country = "AU",
            };

            currentWeatherDataService = new CurrentWeatherDataService(mockLogger.Object, mockAppSettings.Object, mapper, mockOpenWeatherClient.Object);

            var result = await currentWeatherDataService.GetCurrentWeatherData(input);

            // response should be mapped into an output and it should not be null
            Assert.IsNotNull(result);

            // output should show the expected description - sunny
            Assert.That(result.Description, Is.SameAs("sunny"));
        }

        [Test]
        public async Task CurrentWeatherDataService_Can_Handle_Unsuccessful_OpenWeather_Response()
        {
            var input = new CurrentWeatherDataInput()
            {
                City = "Melbourne",
                Country = "AU",
            };

            currentWeatherDataService = new CurrentWeatherDataService(mockLogger.Object, mockAppSettings.Object, mapper, mockOpenWeatherClientWithError.Object);

            var result = await currentWeatherDataService.GetCurrentWeatherData(input);

            // if there is no exception, then everything is all good so far

            // response should be mapped into an output and it should not be null
            Assert.IsNotNull(result);

            // output should show the unsuccessful
            Assert.IsFalse(result.Success);

            // output should show the error/errors
            Assert.IsTrue(result.Errors.Any());
        }
    }
}
