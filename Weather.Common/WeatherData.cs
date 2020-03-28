using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Common
{
	public class WeatherData
	{
		public string Country { get; set; }

		public string City { get; set; }

		public List<WeatherDay> Days { get; set; }

		public WeatherData()
		{
			Days = new List<WeatherDay>();
		}
	}

	public class WeatherDay
	{
		public DateTime DateTime { get; set; }

		public int Temperature { get; set; }

		public string Description { get; set; }

		public int Humidity { get; set; }
	}
}
