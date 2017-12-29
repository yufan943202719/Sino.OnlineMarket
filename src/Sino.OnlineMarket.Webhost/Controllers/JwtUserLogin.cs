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

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public dynamic Login([FromBody] JwtUser body)
        {
            bool authenticated = false;
            
            int entityId = -1;
            string jwtuser = null;
            string token = null;
            DateTime tokenExpires = default(DateTime);
            var currentUser = HttpContext.User;
            authenticated = currentUser.Identity.IsAuthenticated;
                if (authenticated)
                {
                    jwtuser = currentUser.Identity.Name;
                foreach (Claim c in currentUser.Claims)
                {
                    if (c.Type == "EntityID")
                        entityId = Convert.ToInt32(c.Value);
                }
                    tokenExpires = DateTime.UtcNow.AddMinutes(2);
                    token = tr.GenerateToken(body.UserName, tokenExpires);
                }
            return new { authenticated = authenticated, jwtuser = body.UserName, entityId = entityId, token = token, tokenExpires = tokenExpires };
            /*
            

            return $"Hello! {HttpContext.User.Identity.Name}, your ID is:{id}";
            */
        }

        /// <summary>
        /// 重置一个新的Token值
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("GetAuthToken")]
        public dynamic GetAuthToken([FromBody] JwtUser user)
        {
            var existUser = DB.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName) && u.UserPassword.Equals(user.UserPassword));

            if (existUser != null)
            {
                DateTime expires = DateTime.UtcNow.AddMinutes(2);
                var token = tr.GenerateToken(user.UserName, expires);
                return new { authenticated = true, entityId = 1, token = token, tokenExpires = expires };
            }
            return new { authenticated = false ,Msg = "用户名或密码错误"};
        }
       
    }

}
