using Sino.OnlineMarket.Repositories.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Repositories.Repository
{
    public class UsersRepository
    {
        OnlineMarketContext DB = new OnlineMarketContext();

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<Users> GetAllUsers()
        {
            List<Users> listusers = new List<Users>();
            listusers = DB.Users.ToList();
            return listusers;
        }

        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="Id">用户编号</param>
        /// <returns></returns>
        public async Task<Users> GetUserById(int Id)
        {
            Users user = new Users();
            try
            {
                await Task.Run(() =>
                {
                    user = DB.Users.FirstOrDefault(x => x.UserId == Id);
                });
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        //删除用户  未完待续

    }
}
