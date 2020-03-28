using Newtonsoft.Json;

namespace Weather.Common
{
	public class OpenWeatherMapWeatherData
	{
		[JsonProperty("temp")]
		public double Value { get; set; }

		[JsonProperty("humidity")]
		public int Humidity { get; set; }
	}
}
