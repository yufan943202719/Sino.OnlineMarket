using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.ValueModel
{

    /// <summary>
    /// 生活指数列表
    /// </summary>
    public class IndexListVM
    {
        /// <summary>
        /// 指数名称
        /// </summary>
        public string Iname { get; set; }

        /// <summary>
        /// 指数值
        /// </summary>
        public string Ivalue { get; set; }

        /// <summary>
        /// 指数详情
        /// </summary>
        public string Detail { get; set; }
    }
}
