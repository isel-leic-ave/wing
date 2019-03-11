using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Clima;
using System.Collections.Generic;

namespace Csvier.Test
{
    [TestClass]
    public class ClimaTest
    {
        [TestMethod]
        public void TestLoadSearchOporto()
        {
            using (WeatherWebApi api = new WeatherWebApi())
            {
                LocationInfo[] locals = api.Search("oporto");
                Assert.AreEqual(6, locals.Length);
                Assert.AreEqual("Cuba", locals[5].Country);
            }
        }

        [TestMethod]
        public void TestLoadPastWeatherOnJanuaryAndCheckMaximumTempC()
        {
            using (WeatherWebApi api = new WeatherWebApi())
            {
                IEnumerable<WeatherInfo> infos = api.PastWeather(37.017, -7.933, DateTime.Parse("2019-01-01"), DateTime.Parse("2019-01-30"));
                int max = int.MinValue;
                foreach (WeatherInfo wi in infos)
                {
                    if (wi.TempC > max) max = wi.TempC;
                }
                Assert.AreEqual(19, max);
                // Console.WriteLine(String.Join("\n", infos));
            }
        }
    }
}
