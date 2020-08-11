using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.WeChat.Pub.Client
{
    /// <summary>
    /// 查询访问凭据
    /// </summary>
    public class TokenRequest : BaseRequest
    {
        /// <summary>
        /// 第三方用户唯一凭证
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 第三方用户唯一凭证密钥
        /// </summary>
        public string AppSecret { get; set; }
    }
}
