using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Common
{
	public interface IWeatherService
	{
		WeatherData Get(string city);

		WeatherData Get(string latitude, string longitude);

		Task<WeatherData> GetAsync(string city);

		Task<WeatherData> GetAsync(string latitude, string longitude);
	}
}
