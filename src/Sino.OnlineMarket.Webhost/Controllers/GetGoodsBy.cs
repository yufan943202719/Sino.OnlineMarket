using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Webhost.ViewModel;
using Sino.OnlineMarket.Repositories.Repository;
using Sino.OnlineMarket.Repositories.ViewModel;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{

    /// <summary>
    /// 商品搜索
    /// </summary>
    [Route("sino/[controller]")]
    [Authorize]
    public class GetGoodsBy : Controller
    {
        private GoodsRepository gr = new GoodsRepository();
        private Goods g = new Goods();

        /// <summary>
        /// 通过商品名字搜索
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[HttpGet("GetGoodsByName")]
        /* public async Task<GoodsListResponseForU> GetGoodsByName(string name)
         {
             GoodsListResponseForU response = new GoodsListResponseForU();
             response.ToalCount = gr.GetGoodsDetialByName(name).Result.Count;
             List<Goods> goods = new List<Goods>();
             goods = await gr.GetGoodsDetialByName(name);
             List<GoodsItemListForU> list = new List<GoodsItemListForU>();

             for(int i = 0;i < goods.Count; i++)
             {
                 GoodsItemListForU goodsitem = new GoodsItemListForU();
                 goodsitem.GoodsId = goods[i].GoodsId;
                 goodsitem.GoodsName = goods[i].GoodsName;
                 goodsitem.GoodsPrice = goods[i].GoodsPrice;
                 goodsitem.GoodsNum = goods[i].GoodsNum;
                 list.Add(goodsitem);
             }
             response.GoodsItemListGorU = list;

             return response;
         }*/
        [HttpGet("GetGoodsByName")]
        public async Task<List<GoodsItemListForU>> GetGoodsByName(string name)
        {
            GoodsListResponseForU response = new GoodsListResponseForU();
            response.ToalCount = gr.GetGoodsDetialByName(name).Result.Count;
            List<Goods> goods = new List<Goods>();
            goods = await gr.GetGoodsDetialByName(name);
            

            for (int i = 0; i < goods.Count; i++)
            {
                GoodsItemListForU goodsitem = new GoodsItemListForU();
                goodsitem.GoodsId = goods[i].GoodsId;
                goodsitem.GoodsName = goods[i].GoodsName;
                goodsitem.GoodsPrice = goods[i].GoodsPrice;
                goodsitem.GoodsNum = goods[i].GoodsNum;
                response.GoodsItemListGorU.Add(goodsitem);
            }


            return response.GoodsItemListGorU;
        }

        /// <summary>
        /// 通过商品编码搜索
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetGoodsById")]
        public async Task<GoodsItem> GetGoodsById(string Id)
        {
            Goods goods = new Goods();
            if (Id != "")
            {
                goods = await gr.GetGoodsDetital(Id);
            }

            GoodsItem goodsitem = new GoodsItem();
            goodsitem.GoodsId = goods.GoodsId;
            goodsitem.GoodsName = goods.GoodsName;
            goodsitem.GoodsPrice = goods.GoodsPrice;
            goodsitem.GoodsKind = goods.GoodsKind;
            goodsitem.GoodsNum = goods.GoodsNum;
            return goodsitem;
        }

    }
}
