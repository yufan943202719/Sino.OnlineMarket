using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    public class GoodsListWithKindResponseForU
    {

        public int TotalCount { get; set; }

        public string GoodsKind { get; set; }

        public List<GoodsListItemForU> GoodsListItemForU { get; set; }
    }

    public class GoodsListItemForU
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
    }
}
