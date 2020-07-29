using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.Request
{
    /// <summary>
    /// 请求退款
    /// </summary>
    public class RefundRequest : BaseRequest
    {
        /// <summary>
        /// 支付平台订单号（优先使用）
        /// </summary>
        public string PayPlatformTradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户退款号
        /// </summary>
        public string RefundNo { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public int RefundFee { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
    }
}
