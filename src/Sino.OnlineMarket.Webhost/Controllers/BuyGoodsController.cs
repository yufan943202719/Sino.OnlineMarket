using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Repositories;
using Sino.OnlineMarket.Repositories.Repository;
using Sino.OnlineMarket.Repositories.ViewModel;
using Sino.OnlineMarket.Webhost.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    [Route("sino/[controller]")]
    public class BuyGoodsController : Controller
    {
        private BuyGoodsRepository BuyGoodsRepository = new BuyGoodsRepository();


        


        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("AddBuyGoods")]
        public async Task<BuyGoodsResponse> TaketoShoppingCar([FromBody] BuyGoods body )
        {
            BuyGoodsResponse response = new BuyGoodsResponse();
            
               
                BuyGoods b = new BuyGoods
                {
                    UserId = body.UserId,
                    GoodsId = body.GoodsId,
                    BuyStatus = 1,
                    BuyDateTime = DateTime.Now
                };
                var count = await BuyGoodsRepository.AddBuyGoods(b);
                if (count > 0)
                {
                    response.ReplyMsg = "添加到购物车成功";
                }
                else
                {
                    response.ReplyMsg = "添加到购物车失败";
                }
                return response;
            }

        

        /// <summary>
        /// 购买商品
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut("AlterBuyGoods")]
        public async Task<BuyGoodsResponse> BuyGoods(int Userid,string Goodsid)
        {
            BuyGoodsResponse response = new BuyGoodsResponse();
           
      
                
                var count = await  BuyGoodsRepository.AlterBuyGoods(Userid,Goodsid);
                if (count > 0)
                {
                    response.ReplyMsg = "购买成功";
                }
                else if (count == -1)
                {
                    response.ReplyMsg = "已经购买";
                }
                else
                {
                    response.ReplyMsg = "购买失败";
                }
                 return response;   
            }      
        



        /// <summary>
        /// 查询购物信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBuyGoods")]
        public async Task<BuyGoodsListResponse> GetBuyGoods(int id)
        {
            BuyGoodsListResponse response = new ViewModel.BuyGoodsListResponse();
            List < BuyGoods > b= await BuyGoodsRepository.GetBuyGoods(id);
            List<BuyGoodsList> bglr = new List<BuyGoodsList>();
            for(int i = 0; i < b.Count; i++)
            {
                BuyGoodsList bgl = new BuyGoodsList
                {
                    UserId = b[i].UserId,
                    GoodsId = b[i].GoodsId,
                    BuyStatus = b[i].BuyStatus,
                    Datetime = b[i].BuyDateTime.ToString()
                };
                bglr.Add(bgl);
            }
            response.BuyGoodsList = bglr;
            return response;
        }



       /// <summary>
       /// 删除购物车中单个商品
       /// </summary>
       /// <param name="Goodsid"></param>
       /// <param name="Userid"></param>
       /// <returns></returns>

        [HttpDelete("DeleteBuyGoodsSingle")]
        public async Task<BuyGoodsResponse> DeleteBuyGoodsSingle(int Userid,string Goodsid)
        {
            BuyGoodsResponse response = new BuyGoodsResponse();
            if (Goodsid == null || Userid == 0)
            {
                response.ReplyMsg = "商品编号不能为空以及人物编号不能为零";
                return response;
            }
            else
            {
                var count=await  BuyGoodsRepository.DeleteBuyGoodsSingle( Userid,Goodsid);
                if (count > 0)
                {
                    response.ReplyMsg = "删除单条信息成功";
                }
                else
                {
                    response.ReplyMsg = "删除单条信息失败";
                }
                return response;
            }
        }
        /// <summary>
        /// 清空购物信息
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        [HttpDelete("DeleteBuyGoodsAll")]
        public async Task<BuyGoodsResponse> DeleteBuyGoodsAll( int Userid)
        {
            BuyGoodsResponse response = new BuyGoodsResponse();
            if ( Userid == 0)
            {
                response.ReplyMsg = "人物编号不能为零";
                return response;
            }
            else
            {
                
                var count = await BuyGoodsRepository.DeleteBuyGoodsAll( Userid );
                if (count > 0)
                {
                    response.ReplyMsg = "清空信息成功";
                }
                else
                {
                    response.ReplyMsg = "清空信息失败";
                }
                return response;
            }
        }
       }
}
