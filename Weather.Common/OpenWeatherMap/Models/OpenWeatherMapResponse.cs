using Newtonsoft.Json;
using System.Collections.Generic;

namespace Weather.Common
{
	public class OpenWeatherMapResponse
	{
		[JsonProperty("city")]
		public OpenWeatherMapCity City { get; set; }

		[JsonProperty("list")]
		public List<OpenWeatherMapWeather> Data { get; set; }
	}
}
