using System.ComponentModel.DataAnnotations;

namespace Sino.OnlineMarket.Repositories.ViewModel
{
    public class Administrators
    {
        /// <summary>
        /// 管理人员编号
        /// </summary>
        [Key]
        public string AdminId { get; set; }

        /// <summary>
        /// 管理密码
        /// </summary>
        public string AdminPasword { get; set; }
    }
}
