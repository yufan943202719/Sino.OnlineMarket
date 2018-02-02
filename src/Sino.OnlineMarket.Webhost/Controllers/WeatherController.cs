using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sino.OnlineMarket.Webhost.ToolMethods;
using Sino.OnlineMarket.Webhost.ViewModel;
using WeatherAPI.ValueModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAPI.controller
{
    [Route("sino/[controller]")]
    public class WeatherController : Controller
    {
        private Weather weather = new Weather();
        /// <summary>
        /// 获取城市天气预报
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="cityid">城市ID</param>
        /// <param name="citycode">城市天气代号</param>
        /// <param name="location">经纬度（纬度在前，逗号分隔）</param>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        [HttpGet("GetWeather")]
        public async Task<WeatherVM> GetWeather(string city = "北京", int cityid = 0, string citycode = "", string location = "", string ip = "")
        {
            string apikey = "48cf24ddfb3c5949";
            string url = "http://api.jisuapi.com/weather/query/" + "?appkey=" + apikey + "&city=" + city + "&cityid=" + cityid + "&citycode=" + citycode + "&location=" + location + "&ip=" + ip;
            var result = await weather.GetHttpResponse(url);
            if (result.status == "0")
            {
                return result.result;
            }
            throw new Exception(result.msg);
        }
       
    }
}
