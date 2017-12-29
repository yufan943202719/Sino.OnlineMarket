using Sino.OnlineMarket.Repositories.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Repositories.Repository
{
    public class UsersRepository
    {
        private OnlineMarketContext DB = new OnlineMarketContext();

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="users">用户</param>
        /// <returns></returns>
        public async Task<int> AddUsers(Users users)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    DB.Users.Add(users);
                    count = DB.SaveChanges();
                });
            }
            catch (Exception ex) { Console.WriteLine("出错啦！" + ex.Message.ToString()); }
            return count;
        }


        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <returns></returns>
        public int CheckUsersByName(string Name)
        {
            List<Users> users = DB.Users.Where(x => x.UserName.Equals(Name)).ToList();
            return users.Count;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName">账号</param>
        /// <param name="UserPassword">密码</param>
        /// <returns></returns>
       /* public Users GetUsers(string UserName, string UserPassword)
        {
            Users user = new Users();
            List<Users> listuser = new List<Users>();

        }
        */


        /// <summary>
        /// 查询个人信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public async Task<Users> GetUserById(int id)
        {
            Users u = new Users();
            
            try
            {
                await Task.Run(() =>
                {
                    u = DB.Users.FirstOrDefault(t => t.UserId == id);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取错误信息：{0}", ex.Message.ToString());
            }
            return u;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="users">用户</param>
        /// <returns></returns>
        public async Task<int> AlterUserInfo(Users users)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    var u = DB.Users.FirstOrDefault(x => x.UserId == users.UserId);
            
                    if (users.UserName != u.UserName)
                    {
                        u.UserName = users.UserName;
                    }
                    if (users.UserPassword != u.UserPassword)
                    {
                        u.UserPassword = users.UserPassword ;
                    }
                    if (users.Sex != u.Sex)
                    {
                        u.Sex= users.Sex;
                    }
                    if (users.PhoneNum != u.PhoneNum)
                    {
                        u.PhoneNum = users.PhoneNum;
                    }
                    if (users.Address != u.Address)
                    {
                       u.Address = users.Address;
                    }
                    if (users.PostalCode != u.PostalCode)
                    {
                        u.PostalCode= users.PostalCode;
                    }
                    count = DB.SaveChanges();
                });
            }
            catch (Exception ex) { Console.WriteLine("出错啦！" + ex.Message.ToString()); }
            return count;
        }

        }
    }

