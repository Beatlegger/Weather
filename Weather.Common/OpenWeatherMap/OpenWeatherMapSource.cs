using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Common
{
	public class OpenWeatherMapSource : IWeatherSource
	{
		private const string URI_LOC_TEMPLATE = @"http://api.openweathermap.org/data/2.5/forecast?{0}&appid={1}";

		private HttpClient _httpClient = new HttpClient();
		private string _key = string.Empty;

		public OpenWeatherMapSource(string key)
		{
			_key = key;
		}

		public WeatherData Get(string city)
		{
			return GetAsync(city).Result;
		}

		public WeatherData Get(string latitude, string longitude)
		{
			return GetAsync(latitude, longitude).Result;
		}

		public async Task<WeatherData> GetAsync(string city)
		{
			var response = await RequestAsync(new Dictionary<string, string> { { "q", city } }).ConfigureAwait(false);

			return ConvertResponse(response);
		}

		public async Task<WeatherData> GetAsync(string latitude, string longitude)
		{
			var response = await RequestAsync(new Dictionary<string, string>
			{
				{ "lat", latitude },
				{ "lon", longitude }
			})
			.ConfigureAwait(false);

			return ConvertResponse(response);
		}

		private WeatherData ConvertResponse(OpenWeatherMapResponse response)
		{
			return new WeatherData
			{
				Country = new RegionInfo(response.City.Country).EnglishName,
				City = response.City.Name,
				Days = response.Data.GroupBy(d => d.DateTime.Date).Select(w =>
				{
					var description = w.SelectMany(a => a.Description).Select(d => d.Type).FirstOrDefault();
					var mTemp = w.Sum(a => a.Data.Value) / w.Count();
					var mHumidity = w.Sum(a => a.Data.Humidity) / w.Count();
					return new WeatherDay
					{
						Description = OpenWeatherMapDescriptionMaping.Map(description),
						DateTime = w.Key,
						Temperature = Convert.ToInt32(mTemp - 273.15),
						Humidity = mHumidity
					};
				}).ToList()
			};
		}

		private async Task<OpenWeatherMapResponse> RequestAsync(Dictionary<string, string> query)
		{
			var queryPart = String.Join("&", query.Select(kv => $"{kv.Key}={kv.Value}"));
			var requestUri = String.Format(URI_LOC_TEMPLATE, queryPart, _key);
			var responseString = await _httpClient.GetStringAsync(requestUri);
			return JsonConvert.DeserializeObject<OpenWeatherMapResponse>(responseString);
		}
	}
}
