using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.ValueModel
{
    /// <summary>
    /// 天气（按天时间）
    /// </summary>
    public class DailyListVM
    {
        public string Date { get; set; }
        public string Week { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public WeatherInfo Night { get; set; }
        public WeatherInfo Day { get; set; }
    }
    public class WeatherInfo
    {
        public string Weather { get; set; }
        public string Templow { get; set; }
        public string Img { get; set; }
        public string Winddirect { get; set; }
        public string Windpower { get; set; }
    }
}
