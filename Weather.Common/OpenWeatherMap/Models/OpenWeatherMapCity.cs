using Newtonsoft.Json;

namespace Weather.Common
{
	public class OpenWeatherMapCity
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }
	}
}
