using System.Collections.Generic;

namespace Weather.Common
{
	public static class OpenWeatherMapDescriptionMaping
	{
		private static readonly Dictionary<string, string> _map = new Dictionary<string, string>
		{
			{ "clear", "Sun" },
			{ "rain", "Rain"},
			{ "drizzle", "Rain"},
			{ "tornado", "Rain"},
			{ "thunderstorm", "Rain"},
			{ "snow", "Snow" },
			{ "clouds", "Cloud"},
			{ "mist", "Mist"},
			{ "smoke", "Mist"},
			{ "haze", "Mist"},
			{ "dust", "Mist"},
			{ "fog", "Mist"},
			{ "sand", "Mist"},		
			{ "ash", "Mist"},
			{ "squall", "Mist"},
		};

		public static string Map(string value)
		{
			return _map.ContainsKey(value.ToLower())
				? _map[value.ToLower()]
				: "Mist";
		}
	}
}
