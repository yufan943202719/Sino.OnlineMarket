using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.ValueModel;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    public class WeatherPage
    {
        public string status { get; set; }
        public string msg { get; set; }
        public WeatherVM result { get; set; }
    }
}
