using Sino.OnlineMarket.Repositories.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Repositories.Repository
{
    public class AdministratorsRepository
    {
        private OnlineMarketContext DB = new OnlineMarketContext();

        /// <summary>
        ///管理人员登陆后台
        /// </summary>
        /// <param name="adminId">管理人员账户</param>
        /// <param name="password">管理登陆密码</param>
        /// <returns></returns>
        public Administrators GetAdministrator(string adminId,string password)
        {
            Administrators admin = new Administrators();
            List<Administrators> listadmin = DB.Administrators.ToList();
            if(listadmin.Count == 0)
            {
                Administrators a = new Administrators
                {
                    AdminId = "ad12345",
                    AdminPasword = "abc123"
                };
                DB.Administrators.Add(a);
                DB.SaveChanges();
            }
            listadmin = DB.Administrators.ToList();
            listadmin = listadmin.Where(x => x.AdminId == adminId && x.AdminPasword == password).ToList();
            if(listadmin.Count > 0)
            {
                admin = listadmin.First();
            }
            return admin;
        }

        /// <summary>
        /// 修改管理人员登陆密码
        /// </summary>
        /// <param name="adminId">管理人员账户</param>
        /// <param name="Pwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public int EditAdminPwd(string adminId = null,string Pwd = null,string newPwd = null)
        {
            int count = 0;
            try
            {
                Administrators Ad = DB.Administrators.First(x => x.AdminId == adminId & x.AdminPasword == Pwd);
                Ad.AdminPasword = newPwd;
                count = DB.SaveChanges();
            }
            catch(Exception ex) { }
            return count; 
        }

    }
}
