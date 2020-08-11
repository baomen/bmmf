using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub.Models
{
    /// <summary>
    /// 公众号的响应基类
    /// </summary>
    [Serializable]
    public abstract class BaseResponse
    {
        /// <summary>
        ///  errcode	 错误代码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// errmsg	 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
