using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Webhost.ViewModel;
using Sino.OnlineMarket.Repositories.ViewModel;
using Sino.OnlineMarket.Repositories.Repository;
using System.IO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    /// <summary>
    /// 商品分类管理
    /// </summary>
    [Route("sino/[controller]")]
    public class GoodsControllersByKinds : Controller
    {
        private GoodsRepository gr = new GoodsRepository();
        private Goods g = new Goods();

        /// <summary>
        /// 分类显示商品
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        [HttpGet("GetGoodsByKind")]
       public async Task<GoodsListWithKindResponseForA> GetGoodsByKind(string kind)
        {
            GoodsListWithKindResponseForA response = new GoodsListWithKindResponseForA();
            List<Goods> listgoods = await gr.GetAllGoodsWithKind(kind);
            response.TotalCount = gr.GetAllGoodsWithKind().Result.Count;
            List<GoodsListItem> goodslistitem = new List<GoodsListItem>();
            for(int i = 0;i < listgoods.Count; i++)
            {
                GoodsListItem gli = new GoodsListItem();
                gli.GoodsId = listgoods[i].GoodsId;
                gli.GoodsId = listgoods[i].GoodsId;
                gli.GoodsName = listgoods[i].GoodsName;
                gli.GoodsPrice = listgoods[i].GoodsPrice;
                gli.GoodsNum = listgoods[i].GoodsNum;
                gli.CreateDateTime = listgoods[i].CreateDateTime;
                goodslistitem.Add(gli);
            }
            response.GoodsList = goodslistitem;
            return response;
        }


        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        // GET: api/values
        [HttpPost("AddGoods")]
        public async Task<GoodsResponse> AddGoods([FromBody] GoodsItem body)
        {
            GoodsResponse response = new GoodsResponse();
            if (body.GoodsId == "")
            {
                response.ReplyMsg = "商品编码不能为空";
                return response;
            }
            else if (gr.CheckGoodsById(body.GoodsId) > 1)
            {
                response.ReplyMsg = "该商品已存在";
                return response;
            }
            else if (body.GoodsName == "")
            {
                response.ReplyMsg = "商品名称不能为空";
                return response;
            }
            else if (body.GoodsPrice == 0)
            {
                response.ReplyMsg = "商品价格不能为0";
                return response;
            }
            else if (body.GoodsNum == 0)
            {
                response.ReplyMsg = "商品库存不能为空";
                return response;
            }
            else
            {
                /* var file = HttpContext.Request.Form.Files[0];
                Stream stream = file.OpenReadStream();
                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var ImagePath = gr.StreamToFile(stream, fileName);
                string gname = g.GoodsName;
                */
                Goods goods = new Goods
                {
                    GoodsId = body.GoodsId,
                    GoodsName = body.GoodsName,
                    GoodsPrice = body.GoodsPrice,
                    GoodsKind = body.GoodsKind,
                    GoodsNum = body.GoodsNum,
                    CreateDateTime = DateTime.Now

                };
                var count = await gr.AddGoods(goods);
                if (count > 0)
                {
                    response.ReplyMsg = "商品上架成功";
                }
                else
                {
                    response.ReplyMsg = "商品上架失败";
                }
                return response;
            }
        }
           
        /*(未完待续)
   /// <summary>
   /// 修改商品信息
   /// </summary>
   /// <param name="Id"></param>
   /// <returns></returns>
   [HttpGet("AlterGoodsById")]
   public async Task<GoodsResponse> AlterGoodsById(string Id)
   {

   }
   */

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="Id">商品编码</param>
        /// <returns></returns>
        [HttpGet("DeleteGoodsById")]
        public async Task<GoodsResponse> DeleteGoodsById(string Id)
        {
            GoodsResponse response = new GoodsResponse();
            if (Id == "")
            {
                response.ReplyMsg = "商品编码不能为空";
                return response;
            }
            else
            {
                var count = await gr.DelGoodsWithId(Id);
                if (count > 0)
                {
                    response.ReplyMsg = "商品下架成功";
                }
                else
                {
                    response.ReplyMsg = "商品下架失败";
                }
                return response;
            }
        }
    }
}
