using BaoMen.AliYun;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoMen.MultiMerchant.AliYun
{
    /// <summary>
    /// 配置
    /// </summary>
    public class Config : IConfig
    {
        /// <summary>
        /// 身份验证凭据
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 身份验证凭据密钥
        /// </summary>
        public string AccessKeySecret { get; set; }
    }
}
