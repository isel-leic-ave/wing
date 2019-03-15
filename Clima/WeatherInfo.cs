using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima
{
    public class WeatherInfo
    {
        public DateTime Date { get;  }
        public int TempC { get; }
        public double PrecipMM { get; set; }
        public String Desc { get; set; }

        public WeatherInfo()
        {
        }

        public WeatherInfo(DateTime date)
        {
            this.Date = date;
        }

        public WeatherInfo(DateTime date, int tempC)
        {
            this.Date = date;
            this.TempC = tempC;
        }

        public override String ToString()
        {
            return "WeatherInfo{" +
                "date=" + Date +
                ", tempC=" + TempC +
                ", precipMM=" + PrecipMM +
                ", desc='" + Desc + '\'' +
                '}';
        }

    }
}
