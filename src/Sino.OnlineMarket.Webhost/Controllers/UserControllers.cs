using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Webhost.ViewModel;
using Sino.OnlineMarket.Repositories.ViewModel;
using Sino.OnlineMarket.Repositories.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    
    /// <summary>
    /// 管理用户
    /// </summary>
    [Route("sino/[controller]")]
    public class UserControllers : Controller
    {

        private AUsersRepository ur = new AUsersRepository();

        /// <summary>
        /// 显示所有用户信息
        /// </summary>
        /// <returns></returns>
       [HttpGet("GetAllUsers")]
       public UsersListItem GetAllUsers()
        {
            UsersListItem response = new UsersListItem();
            List<Users> listusers = ur.GetAllUsers();
            response.TotalCount = ur.GetAllUsers().Count;
            List<UserItem> useritem = new List<UserItem>();
            for(int i = 0;i < listusers.Count; i++)
            {
                UserItem ui = new UserItem();
                ui.UserId = listusers[i].UserId;
                ui.UserName = listusers[i].UserName;
                ui.UserPassword = listusers[i].UserPassword;
                ui.Sex = listusers[i].Sex;
                ui.PhoneNum = listusers[i].PhoneNum;
                ui.Address = listusers[i].Address;
                ui.PostalCode = listusers[i].PostalCode;
                useritem.Add(ui);
            }
            response.UserItem = useritem;
            return response;
            
        }

        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetUserById")]
        public async Task<Users> GetUserById(int Id)
        {
            Users user = await ur.GetUserById(Id);

            return user;
        }

        //删除用户  未完待续
    }
}
