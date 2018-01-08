using Sino.OnlineMarket.Repositories.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;


namespace Sino.OnlineMarket.Repositories.Repository
{
    public class GoodsRepository
    {
        private OnlineMarketContext DB = new OnlineMarketContext();
       
        /// <summary>
        ///增加商品 
        /// </summary>
        /// <param name="goods">商品</param>
        /// <returns></returns>
        public async Task<int> AddGoods(Goods goods)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    DB.Goods.Add(goods);
                    count = DB.SaveChanges();
                });
            }
            catch (Exception ex) { Console.WriteLine("出错啦！" + ex.Message.ToString()); }
            return count;
        }
        /*
        /// <summary>
        /// 商品图片路径
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]   
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始   
            stream.Seek(0, SeekOrigin.Begin);

            // 把 byte[] 写入文件   
            var path = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, @"Images");
            string s = @"/";
            var ImagePath = path + s + fileName;
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Flush();
            fs.Flush();

            return ImagePath;
        }
        */

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public async Task<int> EditGoods(Goods goods)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    Goods g = DB.Goods.FirstOrDefault(x => x.GoodsId == goods.GoodsId);
                    if (goods.GoodsName != g.GoodsName)
                    {
                        g.GoodsName = goods.GoodsName;
                    }
                    if (goods.GoodsPrice != g.GoodsPrice)
                    {
                        g.GoodsPrice = goods.GoodsPrice;
                    }
                    if (goods.GoodsKind != g.GoodsKind)
                    {
                        g.GoodsKind = goods.GoodsKind;
                    }
                 
                    if (goods.GoodsNum != g.GoodsNum)
                    {
                        g.GoodsNum = goods.GoodsNum;
                    }

                    g.CreateDateTime = goods.CreateDateTime;

                    count = DB.SaveChanges();
                });
            }
            catch (Exception ex) { Console.WriteLine("出错啦！" + ex.Message.ToString()); }
            return count;
        }

        /// <summary>
        /// 通过商品编码获取商品详情
        /// </summary>
        /// <param name="Id">商品编码</param>
        /// <returns></returns>
        public async Task<Goods> GetGoodsDetital(string Id)
        {
            Goods goods = new Goods();
            try
            {
                await Task.Run(() =>
                {
                    goods = DB.Goods.FirstOrDefault(x => x.GoodsId == Id);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"该商品已下架！详情：{ex.Message.ToString()}");
            }
            return goods;
        }

        /// <summary>
        /// 通过商品名称获取商品详情
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Goods>> GetGoodsDetialByName(string name)
        {
            List<Goods> goods = new List<Goods>();
            try
            {
                await Task.Run(() =>
                {
                    goods = DB.Goods.Where(x => x.GoodsName.IndexOf(name) > -1).ToList();
                });
            }
            catch(Exception ex) { }
            return goods;
        }


        /// <summary>
        /// 获取所有商品信息
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetAllGoodsList()
        {
            return DB.Goods.ToList();
        }

        public async Task<List<Goods>> GetAllGetGoods()
        {
            List<Goods> list = new List<Goods>();
            await Task.Run(() =>
            {
                list = DB.Goods.ToList();
            });
            return list;
        }

        /// <summary>
        /// 通过商品类型查找
        /// </summary>
        /// <param name="Kind">商品类型</param>
        /// <returns></returns>
        public async Task<List<Goods>> GetAllGoodsWithKind(string Kind = null)
        {
            List<Goods> listgoods = new List<Goods>();
            var goodslist = DB.Goods.ToList();
            try
            {
                await Task.Run(() =>
                {
                    if (Kind != null)
                    { listgoods = goodslist.Where(x => x.GoodsKind == Kind).ToList(); }
                    else { listgoods = goodslist.ToList(); }
                });
            }
            catch (Exception ex) { Console.WriteLine("出错啦！" + ex.Message.ToString()); }
            return listgoods;
        }

        /// <summary>
        /// 通过编码删除单个商品
        /// </summary>
        /// <param name="Id">商品编码</param>
        /// <returns></returns>
        public async Task<int> DelGoodsWithId (string Id)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    var goods = DB.Goods.FirstOrDefault(x => x.GoodsId == Id);
                    DB.Goods.Remove(goods);
                    count = DB.SaveChanges();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错啦！" + ex.Message.ToString());
            }
            return count;
        }

        /// <summary>
        /// 删除一类商品
        /// </summary>
        /// <param name="Kind">商品类型</param>
        /// <returns></returns>
        public async Task<int> DelGoodsWithKind (string Kind)
        {
            int count = 0;
            List<Goods> listgoods = new List<Goods>();
            var goodslist = DB.Goods.ToList();
            try
            {
                await Task.Run(() =>
                {
                    listgoods = goodslist.Where(x => x.GoodsKind == Kind).ToList();
                    foreach (Goods g in listgoods)
                    {
                        DB.Goods.Remove(g);
                    }
                    count = DB.SaveChanges();
                });
            }
            catch(Exception ex) { Console.WriteLine("出错啦！" + ex.Message.ToString()); }
            return count;
        } 

        /// <summary>
        /// 验证商品是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int CheckGoodsById(string Id)
        {
            List<Goods> goods = DB.Goods.Where(x => x.GoodsId == Id).ToList();
            return goods.Count;
        }

    }
}
