using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.Request
{
    /// <summary>
    /// 请求参数的基类
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MerchantId { get; set; }
    }
}
