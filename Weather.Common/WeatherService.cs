using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Common
{
	public class WeatherService : IWeatherService
	{
		private IWeatherSource _weatherSource;
		public WeatherService(IWeatherSource weatherSource)
		{
			_weatherSource = weatherSource;
		}

		public WeatherData Get(string city)
		{
			throw new NotImplementedException();
		}

		public WeatherData Get(string latitude, string longitude)
		{
			throw new NotImplementedException();
		}

		public async Task<WeatherData> GetAsync(string city)
		{
			return await _weatherSource.GetAsync(city);
		}

		public async Task<WeatherData> GetAsync(string latitude, string longitude)
		{
			return await _weatherSource.GetAsync(latitude, longitude);
		}
	}
}
