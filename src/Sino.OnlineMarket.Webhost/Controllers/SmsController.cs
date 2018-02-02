using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Webhost.ToolMethods;
using Sino.OnlineMarket.Webhost.ToolModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    /// <summary>
    /// 短信接口
    /// </summary>
    [Route("sino/[controller]")]
    public class SmsController : Controller
    {
        private SmsSend smsend = new SmsSend();

        #region 此接口暂不可用

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="phone">手机号码（大于1个用逗号隔开）</param>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet("PushSms")]
       public async Task<SmsVM> PushSms(string phone,string context)
        {
            string apikey = "48cf24ddfb3c5949";
            string url = "http://api.jisuapi.com/sms/send/" + "?appkey=" + apikey + "&phone=" + phone + "&context=" + context;
            var response = await smsend.GetHttpResponse(url);
            if (response.status == "0")
            {
                return response.result;
            }
            throw new Exception(response.msg);
        }
        #endregion
    }
}