using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.ValueModel
{
    /// <summary>
    /// 详细天气信息
    /// </summary>
    public class WeatherVM
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        public int Cityid { get; set; }

        /// <summary>
        /// 城市天气代号
        /// </summary>
        public string Citycode { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 星期
        /// </summary>
        public string Week { get; set; }

        /// <summary>
        /// 天气
        /// </summary>
        public string Weather { get; set; }

        /// <summary>
        /// 气温
        /// </summary>
        public string Temp { get; set; }

        /// <summary>
        /// 最高气温
        /// </summary>
        public string Temphigh { get; set; }

        /// <summary>
        /// 最低气温
        /// </summary>
        public string Templow { get; set; }

        /// <summary>
        /// 图片数字
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public string Humidity { get; set; }

        /// <summary>
        /// 气压
        /// </summary>
        public string Pressure { get; set; }

        /// <summary>
        /// 风速
        /// </summary>
        public string Windspeed { get; set; }

        /// <summary>
        /// 风向
        /// </summary>
        public string Winddirect { get; set; }

        /// <summary>
        /// 风级
        /// </summary>
        public string Windpower { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public string Updatetime { get; set; }

        /// <summary>
        /// 生活指数
        /// </summary>
        public List<IndexListVM> Index { get; set; }

        /// <summary>
        /// AQI指数
        /// </summary>
        public AqiVM Aqi { get; set; }

        public List<DailyListVM> Daily { get; set; }
        public List<HourlyListVM> Hourly { get; set; }
    }
}
