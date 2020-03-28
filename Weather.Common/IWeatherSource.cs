using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather.Common
{
	public interface IWeatherSource
	{
		WeatherData Get(string city);

		WeatherData Get(string latitude, string longitude);

		Task<WeatherData> GetAsync(string city);

		Task<WeatherData> GetAsync(string latitude, string longitude);
	}
}
