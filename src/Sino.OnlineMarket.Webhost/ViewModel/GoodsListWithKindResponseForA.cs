using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    /// <summary>
    /// 单类呈现商品列表
    /// </summary>
    public class GoodsListWithKindResponseForA
    {
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsKind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<GoodsListItem> GoodsList { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GoodsListItem
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public double GoodsPrice { get; set; }

        /// <summary>
        /// 商品图片存放地址
        /// </summary>
        public string GoodsImagePath { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        public int GoodsNum { get; set; }

        /// <summary>
        /// 商品录入时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }


    }
}
