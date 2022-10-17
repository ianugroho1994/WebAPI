using Common;
using Common.Helpers;
using Common.Interfaces;
using Common.Models;
using Weather.UseCases;

namespace Weather
{
    public class WeatherModule : IWeatherDomain
    {
        private readonly LogHelper _logger;
        private readonly Producer _producer;
        private readonly GetWeatherUseCase _getWeatherUseCase;

        public WeatherModule(LogHelper log, Producer producer)
        {
            _logger = log;
            _producer = producer;
            _getWeatherUseCase = new GetWeatherUseCase(_logger);
        }

        public void InitializeModule()
        {
            _producer.RegisterModule(this);
            _logger.LogInfo("protocol module initialized");
        }

        public void TerminateModule()
        {
            _logger.LogInfo("protocol module terminated");
        }

        public IEnumerable<WeatherForecast> Get() => _getWeatherUseCase.Get();
    }
}
