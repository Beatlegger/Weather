using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Common;

namespace Weather.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherController : ControllerBase
	{
		IWeatherSource _weatherService;

		public WeatherController(IWeatherSource weatherService)
		{
			_weatherService = weatherService;
		}

		[HttpGet]
		public IEnumerable<WeatherData> Get(
			[FromQuery(Name = "city")] string city,
			[FromQuery(Name = "lat")] string latitude, 
			[FromQuery(Name = "lon")] string longitude)
		{
			return _weatherService.Get(city);
		}
	}
}
