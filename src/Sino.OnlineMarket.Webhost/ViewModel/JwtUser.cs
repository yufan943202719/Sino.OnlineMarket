using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    public class JwtUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///用户密码 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 当前用户身份
        /// </summary>
        public string audience { get; set; }
    }
}
