using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Repositories.ViewModel
{
    public class BuyGoods
    {
        /// <summary>
        /// 购物信息编号
        /// </summary>

        [Key]
        public int BuyId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>

        public int UserId { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        /// 

        public string GoodsId { get; set; }

        /// <summary>
        /// 购买状态
        /// </summary>
        public int BuyStatus { get; set; }

        /// <summary>
        /// 购物状态更新时间
        /// </summary>
        public DateTime BuyDateTime { get; set; }

    }
}
