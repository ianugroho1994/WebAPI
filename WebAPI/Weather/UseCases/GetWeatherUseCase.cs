using Common.Helpers;
using Common.Models;

namespace Weather.UseCases
{
    internal class GetWeatherUseCase
    {
        private readonly LogHelper _log;
        private static readonly string[] _summaries =
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        public GetWeatherUseCase(LogHelper log)
        {
            _log = log;
        }

        public IEnumerable<WeatherForecast> Get()
        {
            _log.LogInfo("execute get use case");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            })
                             .ToArray();
        }
    }
}
