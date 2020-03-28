using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Common;

namespace Weather.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherController : ControllerBase
	{
		IWeatherService _weatherService;

		public WeatherController(IWeatherService weatherService)
		{
			_weatherService = weatherService;
		}

		[HttpGet]
		public async Task<WeatherData> Get(
			[FromQuery(Name = "city")] string city,
			[FromQuery(Name = "lat")] string latitude,
			[FromQuery(Name = "lon")] string longitude)
		{
			return String.IsNullOrWhiteSpace(city)
				? await _weatherService.GetAsync(latitude, longitude)
				: await _weatherService.GetAsync(city);
		}
	}
}
