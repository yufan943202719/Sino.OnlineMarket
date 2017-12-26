using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Repositories.Repository;
using Sino.OnlineMarket.Webhost.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{

    [Route("sino/[controller]")]
    public class AdministratorController : Controller
    {
        private AdministratorsRepository ar = new AdministratorsRepository();

        /// <summary>
        /// 管理人员登陆
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public AdministratorResponse Login([FromBody] AdministratorLoginItem body)
        {
            AdministratorResponse response = new AdministratorResponse();
            var a = ar.GetAdministrator(body.AdminId, body.AdminPasword);
            if (a > 0) { response.ReplyMsg = "登陆成功"; }
            else response.ReplyMsg = "登陆失败，管理编号或密码错误";
            return response;
        }

       //密码修改  未完待续

    }
}
