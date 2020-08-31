using Newtonsoft.Json;
using System;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram.Models
{
    /// <summary>
    /// 公众号的全局唯一票据
    /// </summary>
    [Serializable]
    public class BaseResponse
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
