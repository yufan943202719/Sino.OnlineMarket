using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    /// <summary>
    /// 用于用户注册
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///用户密码 
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string PhoneNum { get; set; }

        /// <summary>
        /// 收件地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }
    }
}
