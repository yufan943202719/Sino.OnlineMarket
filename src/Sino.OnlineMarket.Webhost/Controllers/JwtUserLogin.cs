using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Sino.OnlineMarket.Webhost.ViewModel;
using Sino.OnlineMarket.Repositories.Repository;
using Sino.OnlineMarket.Repositories.ViewModel;
using Sino.OnlineMarket.Webhost.Auth;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{

    /// <summary>
    /// JWT用户登陆
    /// </summary>
    [Route("sino/[controller]")]
    public class JwtUserLogin : Controller
    {
        private OnlineMarketContext DB = new OnlineMarketContext();
        private TokenRepository tr = new TokenRepository();
        UsersRepository ur = new UsersRepository();

        [HttpGet]
        [Authorize("Bearer")]
        public IEnumerable<string> get()
        {
            return new string[] { "value1", "value2" };
        }
      
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [HttpPost("GetAuthToken")]
        public dynamic GetAuthToken([FromBody] JwtUser user)
        {
            var existUser = DB.Users.FirstOrDefault(u => u.UserName.Equals(user.Name) && u.UserPassword.Equals(user.Password));

            if (existUser != null)
            {

                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                var token = tr.GenerateToken(existUser, expiresIn,user.audience);

                return JsonConvert.SerializeObject(new
                {
                    accessToken = token
                });
            }
            return new { authenticated = false ,Msg = "用户名或密码错误"};
        }
       
    }

}
