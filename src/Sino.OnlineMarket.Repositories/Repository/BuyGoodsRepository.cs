using Sino.OnlineMarket.Repositories.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Repositories.Repository
{
    public class BuyGoodsRepository
    {
        private OnlineMarketContext DB = new OnlineMarketContext();
        /// <summary>
        /// 添加购物信息
        /// </summary>
        /// <param name="buyGoods"></param>
        /// <returns></returns>
        public async Task<int> AddBuyGoods(BuyGoods buyGoods)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    DB.Add(buyGoods);
                    count = DB.SaveChanges();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取错误信息：{0}", ex.Message.ToString());
            }
            return count;
        }
        /// <summary>
        /// 修改购物信息
        /// </summary>
        /// <param name="buyGoods"></param>
        /// <returns></returns>
        public async Task<int> AlterBuyGoods(int Userid, string Goodsid)
        {
            int count = 0;
            try
            {

                var b = DB.BuyGoods.FirstOrDefault(t => t.UserId == Userid && t.GoodsId == Goodsid);


                if (b.BuyStatus == 1)
                {
                    b.BuyDateTime = DateTime.Now;
                    b.BuyStatus = 2;
                    DB.BuyGoods.Update(b);

                    await Task.Run(() =>
                    {
                        count = DB.SaveChanges();

                    });

                }

                else if (count == 0)
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取错误信息：{0}", ex.Message.ToString());
            }
            return count;
        }
        /// <summary>
        /// 查询购物信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<BuyGoods>> GetBuyGoods(int id)
        {
            List<BuyGoods> b = new List<BuyGoods>();
            var buygoodslist = DB.BuyGoods.ToList();
            try
            {
                await Task.Run(() =>
                {
                    b = buygoodslist.Where(t => t.UserId == id).ToList();


                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("获取错误信息：{0}", ex.Message.ToString());

            }
            return b;

        }
        /// <summary>
        /// 删除单个购物记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteBuyGoodsSingle(int Userid, string Goodsid)
        {
            int count = 0;
            try
            {
                await Task.Run(() =>
                {
                    var b = DB.BuyGoods.FirstOrDefault(t => string.Equals(t.GoodsId, Goodsid) && t.UserId == Userid);

                    DB.BuyGoods.Remove(b);
                    count = DB.SaveChanges();

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("获取错误信息：{0}", ex.Message.ToString());
            }
            return count;
        }
        /// <summary>
        /// 删除全部购物记录
        /// </summary>
        /// <param name="Goodsid"></param>
        /// <param name="Userid"></param>
        /// <returns></returns>
        public async Task<int> DeleteBuyGoodsAll(int Userid)
        {
            int count = 0;
            List<BuyGoods> b = new List<BuyGoods>();
            var buygoodslist = DB.BuyGoods.ToList();
            try
            {
                await Task.Run(() =>
                {
                    b = buygoodslist.Where(t => t.UserId == Userid).ToList();

                    DB.BuyGoods.RemoveRange(b);
                    count = DB.SaveChanges();

                });

            }
            catch (Exception ex)
            {
                Console.WriteLine("获取错误信息：{0}", ex.Message.ToString());
            }
            return count;
        }

    }
}
