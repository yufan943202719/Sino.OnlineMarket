using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    public class BuyGoodsListResponse
    {
        /// <summary>
        /// 购物车列表信息条数
        /// </summary>
        public int TotalCount { get; set; }


        /// <summary>
        /// 购物车信息列表
        /// </summary>
        public List<BuyGoodsList> BuyGoodsList { get; set; }
    }

    /// <summary>
    /// 购物信息
    /// </summary>
    public class BuyGoodsList
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public int BuyStatus { get; set; }
        /// <summary>
        /// 购物状态更新时间
        /// </summary>
        public string  BuyDatetime { get; set; }
    }
}
