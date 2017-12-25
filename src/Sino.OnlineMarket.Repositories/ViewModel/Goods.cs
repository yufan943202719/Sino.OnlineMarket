using System;
using System.ComponentModel.DataAnnotations;

namespace Sino.OnlineMarket.Repositories.ViewModel
{
    public class Goods
    {

        /// <summary>
        /// 商品编码
        /// </summary>
        [Key]
        public string  GoodsId { get; set; }

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
