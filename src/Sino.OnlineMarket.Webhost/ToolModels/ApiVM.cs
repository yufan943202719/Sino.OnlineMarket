using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.ValueModel
{
    /// <summary>
    /// AQI指数类
    /// </summary>
    public class AqiVM
    {
        public string So2 { get; set; }
        public string So224 { get; set; }
        public string No2 { get; set; }
        public string No224 { get; set; }
        public string Co { get; set; }
        public string Co24 { get; set; }
        public string O3 { get; set; }
        public string O38 { get; set; }
        public string O324 { get; set; }
        public string Pm10 { get; set; }
        public string Pm1024 { get; set; }
        public string Pm2_5 { get; set; }
        public string Pm2_524 { get; set; }
        public string Iso2 { get; set; }
        public string Ino2 { get; set; }
        public string Ico { get; set; }
        public string Io3 { get; set; }
        public string Io38 { get; set; }
        public string Ipm10 { get; set; }
        public string Ipm2_5 { get; set; }
        public string Aqi { get; set; }
        public string Primarypollutant { get; set; }
        public string Quality { get; set; }
        public string Timepoint { get; set; }
        public AqiInformation Aqiinfo { get; set; }

    }
    /// <summary>
    /// AQI指数信息类
    /// </summary>
    public class AqiInformation
    {
        public string Level { get; set; }
        public string Color { get; set; }
        public string Affect { get; set; }
        public string Measure { get; set; }
    }
}
