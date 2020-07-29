using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pay.Response
{
    /// <summary>
    /// 创建订单响应数据
    /// </summary>
    public class CreateResponse : BaseResponse
    {
        /// <summary>
        /// 二维码链接
        /// </summary>
        public string Url { get; set; }
    }
}
