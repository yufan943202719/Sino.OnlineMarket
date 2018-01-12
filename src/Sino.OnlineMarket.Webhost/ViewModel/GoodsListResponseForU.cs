using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    public class GoodsListResponseForU
    {

        public int ToalCount { get; set; }

        public List<GoodsItemListForU> GoodsItemListGorU = new List<GoodsItemListForU>();
    }

    public class GoodsItemListForU
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
        /// 商品类型
        /// </summary>
        public string GoodsKind { get; set; }

        /// <summary>
        /// 商品库存
        /// </summary>
        public int GoodsNum { get; set; }
    }
}
