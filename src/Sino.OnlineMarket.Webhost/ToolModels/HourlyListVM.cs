using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.ValueModel
{
    /// <summary>
    /// 天气（按小时）
    /// </summary>
    public class HourlyListVM
    {
        public string Time { get; set; }
        public string Weather { get; set; }
        public string Temp { get; set; }
        public string Img { get; set; }
    }
}
