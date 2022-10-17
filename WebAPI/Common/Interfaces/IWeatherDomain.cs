using Common.Models;

namespace Common.Interfaces
{
    public interface IWeatherDomain : IModule
    {
        IEnumerable<WeatherForecast> Get();
    }
}
