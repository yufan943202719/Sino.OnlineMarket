using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Webhost.ViewModel;
using Sino.OnlineMarket.Repositories.ViewModel;
using Sino.OnlineMarket.Repositories.Repository;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    /// <summary>
    ///商品显示
    /// </summary>
    [Route("sino/[controller]")]
    
    public class GoodsShow : Controller
    {

        private GoodsRepository gr = new GoodsRepository();
        private Goods g = new Goods();

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllGoods")]
        [Authorize("Bearer")]
        public GoodsListResponseForU GetAllGoods()
        {
            GoodsListResponseForU response = new GoodsListResponseForU();
            List<Goods> listgoods = gr.GetAllGoodsList();
            response.ToalCount = gr.GetAllGetGoods().Result.Count;
            List<GoodsItemListForU> goodsitemlistforu = new List<GoodsItemListForU>();
            for (int i = 0; i < listgoods.Count; i++)
            {
                GoodsItemListForU gli = new GoodsItemListForU();
                gli.GoodsId = listgoods[i].GoodsId;
                gli.GoodsName = listgoods[i].GoodsName;
                gli.GoodsPrice = listgoods[i].GoodsPrice;
                gli.GoodsKind = listgoods[i].GoodsKind;
                gli.GoodsImagePath = listgoods[i].GoodsImagePath.ToString();
                gli.GoodsNum = listgoods[i].GoodsNum;
                goodsitemlistforu.Add(gli);
            }
            response.GoodsItemListGorU = goodsitemlistforu;
            return response;
        }


        /// <summary>
        /// 分类显示商品
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        [HttpGet("GetGoodsByKind")]
        public async Task<GoodsListWithKindResponseForU> GetGoodsByKind(string kind)
        {
            GoodsListWithKindResponseForU response = new GoodsListWithKindResponseForU();
            List<Goods> listgoods = await gr.GetAllGoodsWithKind(kind);
            response.TotalCount = gr.GetAllGoodsWithKind().Result.Count;
            List<GoodsListItemForU> goodslistitemforu = new List<GoodsListItemForU>();
            for (int i = 0; i < listgoods.Count; i++)
            {
                GoodsListItemForU gli = new GoodsListItemForU();
                gli.GoodsId = listgoods[i].GoodsId;
                gli.GoodsId = listgoods[i].GoodsId;
                gli.GoodsName = listgoods[i].GoodsName;
                gli.GoodsPrice = listgoods[i].GoodsPrice;
                gli.GoodsImagePath = listgoods[i].GoodsImagePath.ToString();
                gli.GoodsNum = listgoods[i].GoodsNum;
                goodslistitemforu.Add(gli);
            }
            response.GoodsListItemForU =goodslistitemforu;
            return response;
        }

    }
}
