using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Weather.Common
{
	public class OpenWeatherMapWeather
	{
		[JsonProperty("dt")]
		public int DateTimeUnixUTC { get; set; }

		[JsonProperty("dt_txt")]
		public DateTime DateTime { get; set; }

		[JsonProperty("main")]
		public OpenWeatherMapWeatherData Data { get; set; }

		[JsonProperty("weather")]
		public List<OpenWeatherMapWeatherDescription> Description { get; set; }
	}
}
