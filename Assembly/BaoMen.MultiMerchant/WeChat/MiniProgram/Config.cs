using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram
{
    /// <summary>
    /// 微信公众号配置
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 微信公众号AppID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 微信公众号密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 接口域名
        /// </summary>
        public string ApiDomain { get; set; }
    }
}
