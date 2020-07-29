using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.Request
{
    /// <summary>
    /// 支付请求
    /// </summary>
    public class CreateRequest : BaseRequest
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public int Fee { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 设备信息
        /// </summary>
        public string Device { get; set; }
    }
}
