using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{

    /// <summary>
    /// 管理员登陆
    /// </summary>
    public class AdministratorLoginItem
    {
        /// <summary>
        /// 管理人员编号
        /// </summary>
        public string AdminId { get; set; }

        /// <summary>
        /// 管理密码
        /// </summary>
        public string AdminPasword { get; set; }
    }
}
