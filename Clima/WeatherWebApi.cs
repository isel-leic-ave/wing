using Csvier;
using Request;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima
{
    public class WeatherWebApi : IDisposable
    {
        const string WEATHER_KEY = "**********************";
        const string WEATHER_HOST = "http://api.worldweatheronline.com/premium/v1/";
        const string PATH_WEATHER = WEATHER_HOST + "past-weather.ashx?q={0},{1}&date={2}&enddate={3}&tp=24&format=csv&key=" + WEATHER_KEY;
        const string SEARCH = WEATHER_HOST + "search.ashx?query={0}&format=tab&key=" + WEATHER_KEY;

        readonly CsvParser pastWeather;
        readonly CsvParser locations;
        readonly IHttpRequest req;

        public WeatherWebApi() : this(new HttpRequest())
        {
        }

        public WeatherWebApi(IHttpRequest req)
        {
            this.req = req;
        }

        public void Dispose()
        {
            req.Dispose();
        }

        public WeatherInfo[] PastWeather(double lat, double log, DateTime from, DateTime to)
        {
            string latStr = lat.ToString("0.000", CultureInfo.InvariantCulture);
            string logStr = log.ToString("0.000", CultureInfo.InvariantCulture);
            throw new NotImplementedException();
        }

        public LocationInfo[] Search(string query) {
            throw new NotImplementedException();
        }
    }
}
