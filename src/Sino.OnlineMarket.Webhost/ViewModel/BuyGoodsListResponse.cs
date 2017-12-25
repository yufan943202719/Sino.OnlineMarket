using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sino.OnlineMarket.Webhost.ViewModel
{
    public class BuyGoodsListResponse
    {

        public List<BuyGoodsList> BuyGoodsList { get; set; }
    }

    public class BuyGoodsList
    {
        public int UserId { get; set; }
        public string GoodsId { get; set; }
        public int BuyStatus { get; set; }
        public string  Datetime { get; set; }
    }
}
