using Newtonsoft.Json;
using Sino.OnlineMarket.Webhost.ToolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ToolMethods
{
    /// <summary>
    /// 发送短信
    /// </summary>
    public class SmsSend
    {
        public async Task<SmsPage> GetHttpResponse(string url)
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
                SmsPage sms = JsonConvert.DeserializeObject<SmsPage>(responseStr);
                return sms;
            }

        }
    }
}
