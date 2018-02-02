using Newtonsoft.Json;
using Sino.OnlineMarket.Webhost.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ToolMethods
{
    public class Weather
    {
        public async Task<WeatherPage> GetHttpResponse(string url)
        {

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                var response = await http.GetAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                string responseStr = response.Content.ReadAsStringAsync().Result;
                WeatherPage weather = JsonConvert.DeserializeObject<WeatherPage>(responseStr);
                return weather;
            }

        }
    }
}
