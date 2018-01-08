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

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="Pwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        [HttpPost("AlterAdminPwd")]
        public AdministratorResponse AlterAdminPwd(string adminId = null, string Pwd = null, string newPwd = null)
        {
            AdministratorResponse response = new AdministratorResponse();
            if (adminId == null)
            {
                response.ReplyMsg = "账号不能为空";
                return response;
            }
            else if (Pwd == null)
            {
                response.ReplyMsg = "原密码不能为空";
                return response;
            }
            else if (newPwd == null)
            {
                response.ReplyMsg = "新密码不能为空";
                return response;
            }
            else
            {
                var count =ar.EditAdminPwd(adminId, Pwd, newPwd);
                if (count > 0)
                {
                    response.ReplyMsg = "密码修改成功";
                }
                else
                {
                    response.ReplyMsg = "密码修改失败";
                }
                return response;
            }
        }

    }
}
