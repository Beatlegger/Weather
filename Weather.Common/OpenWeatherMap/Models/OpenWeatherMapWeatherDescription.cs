using Newtonsoft.Json;

namespace Weather.Common
{
	public class OpenWeatherMapWeatherDescription
	{
		[JsonProperty("main")]
		public string Type { get; set; }
	}
}
