using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sino.OnlineMarket.Repositories.Repository;
using Sino.OnlineMarket.Webhost.ViewModel;
using System.IO;
using Sino.OnlineMarket.Repositories.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sino.OnlineMarket.Webhost.Controllers
{
    /// <summary>
    /// 商品汇总管理
    /// </summary>
    [Route("sino/[controller]")]
    public class GoodsController : Controller
    {
        private GoodsRepository gr = new GoodsRepository();

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllGoods")]
        public GoodsListResponseForA GetAllGoods()
        {
            GoodsListResponseForA response = new GoodsListResponseForA();
            List<Goods> listgoods = gr.GetAllGoodsList();
            response.ToalCount = gr.GetAllGetGoods().Result.Count;
            List<GoodsItemList> goodsitemlist = new List<GoodsItemList>();
            for (int i = 0; i < listgoods.Count; i++)
            {
                GoodsItemList gli = new GoodsItemList();
                gli.GoodsId = listgoods[i].GoodsId;
                gli.GoodsName = listgoods[i].GoodsName;
                gli.GoodsPrice = listgoods[i].GoodsPrice;
                gli.GoodsKind = listgoods[i].GoodsKind;
                gli.GoodsNum = listgoods[i].GoodsNum;
                gli.CreateDateTime = listgoods[i].CreateDateTime;
                goodsitemlist.Add(gli);
            }
            response.GoodsItemList = goodsitemlist;
            return response;
        }

        /// <summary>
        /// 商品编码查询  
        /// </summary>
        /// <param name="Id">商品编码</param>
        /// <returns></returns>
        [HttpGet("SelectGoodsById")]
        public async Task<Goods> SelectGoodsById(string Id)
        {
            Goods goods = new Goods();
            if(Id != "")
            {
                goods = await gr.GetGoodsDetital(Id);
            }
            return goods;
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
            if(body.GoodsId == "")
            {
                response.ReplyMsg = "商品编码不能为空";
                return response;
            }
            if (gr.CheckGoodsById(body.GoodsId) > 0)
            {
                response.ReplyMsg = "该商品已存在";
                return response;
            }
            else if(body.GoodsName == "")
            {
                response.ReplyMsg = "商品名称不能为空";
                return response;
            }
            else if(body.GoodsPrice == 0)
            {
                response.ReplyMsg = "商品价格不能为0";
                return response;
            }
            else if (body.GoodsKind == "")
            {
                response.ReplyMsg = "商品类型不能为空";
                return response;
            }
            else if (body.GoodsNum == 0)
            {
                response.ReplyMsg = "商品库存不能为空";
                return response;
            }
            else
            {
                /*
                 * var file = HttpContext.Request.Form.Files[0];
                Stream stream = file.OpenReadStream();
                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var ImagePath = gr.StreamToFile(stream, fileName);
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


        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("AlterGoodsInfo")]
        public async Task<GoodsResponse> AlterGoodsInfo([FromBody]Goods body)
        {
            GoodsResponse response = new GoodsResponse();
            if (body.GoodsId == "")
            {
                response.ReplyMsg = "商品编码不能为空";
                return response;
            }
            else if (body.GoodsName == "")
            {
                response.ReplyMsg = "商品名称不能为空";
                return response;
            }
            else if(body.GoodsNum.Equals(""))
            {
                response.ReplyMsg = "商品库存不能为空";
                return response;
            }
            else if(body.GoodsKind == "")
            {
                response.ReplyMsg = "商品类型不能为空";
                return response;
            }
            else if(body.GoodsPrice.Equals(""))
            {
                response.ReplyMsg = "商品价格不能为空";
                return response;
            }
            else if(body.CreateDateTime.Equals(""))
            {
                response.ReplyMsg = "商品录入时间不能为空";
                return response;
            }
            else
            {
                var count = await gr.EditGoods(body);
                if (count > 0)
                {
                    response.ReplyMsg = "用户信息修改成功";
                }
                else if (count == 0)
                {
                    response.ReplyMsg = "尚未修改任何信息";
                }
                else
                {
                    response.ReplyMsg = "用户信息修改失败";
                }
                return response;
            }
        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="Id">商品编码</param>
        /// <returns></returns>
        [HttpGet("DeleteGoodsById")]
        public async Task<GoodsResponse> DeleteGoodsById(string Id)
        {
            GoodsResponse response = new GoodsResponse();
            if(Id == "")
            {
                response.ReplyMsg = "商品编码不能为空";
                return response;
            }
            else
            {
                var count = await gr.DelGoodsWithId(Id);
                if(count > 0)
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
